using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServicesBot.Controllers.Commands;
using ServicesBot.Models;
using ServicesBot.Repositories;
using ServicesBot.Repositories.Realizations;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace ServicesBot.Controllers
{
    [ApiController]
    [Route("/")]
    public class BotController : ControllerBase, ITelegramCallBackQuery
    {
        private readonly Dictionary<string, ICommandss> _commands;
        private TelegramBotClient bot = Bot.GetTelegramBotClient();
        private ServicesSubsContext _subsContext;

        public BotController(ServicesSubsContext subsContext)
        {
            _subsContext = subsContext;
            _commands = new Dictionary<string, ICommandss>
            {
                {"/start", new StartCommand() },
                {"/menu", new MenuCommand() },
                {"Личный кабинет", new Personal(_subsContext) },
                {"Сервисы", new ServicesCommand(_subsContext) },
                {"Назад в главное меню", new MenuCommand() },
            };
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Update update)
        {
            if (update.Type == UpdateType.CallbackQuery)
            {
                await HandleCallbackQuery(update.CallbackQuery, update.CallbackQuery.From.Id);
            }
            else
            {
                if (update.Message != null && update.Message.Type == MessageType.Text)
                {
                    var mesText = update.Message.Text;
                    if (_commands.ContainsKey(mesText))
                    {
                        await _commands[mesText].Execute(bot, update.Message);
                    }
                    else
                    {
                        await bot.SendTextMessageAsync(update.Message.Chat.Id, "Что это за команда?");
                    }
                }
            }
            return Ok();
        }

        public async Task HandleCallbackQuery(CallbackQuery callbackQuery, long chatId)
        {
            AllMessages allMessages = new AllMessages();
            KeyboardsFor keyboardsFor=new KeyboardsFor();
            DatabaseService databaseService = new DatabaseService();
            string[] parts;
            int id;
            InlineKeyboardMarkup keyboard;
            UserPeriod userPeriod;
            if (callbackQuery!.Data!.Contains("service_"))
            {
                parts = callbackQuery.Data.Split('_');
                id = Convert.ToInt32(parts[1]);
                userPeriod = databaseService.GetUserPeriod(_subsContext,chatId,id);
                if (userPeriod != null)
                {
                    if (userPeriod.StatusId == 1)
                    {
                        keyboard = new InlineKeyboardMarkup(keyboardsFor.CreateKeyboardChangeStop(userPeriod));
                        await bot.SendTextMessageAsync(chatId: chatId, text: allMessages.InfoAbout(userPeriod), replyMarkup: keyboard);
                    }
                    else
                    {
                        keyboard = new InlineKeyboardMarkup(keyboardsFor.CreateKeyboardRestart(userPeriod));
                        await bot.SendTextMessageAsync(chatId: chatId, text: allMessages.ServiceStop(), replyMarkup: keyboard);
                    }
                }
                else
                {
                    List<Period> periods = databaseService.GetPeriods(_subsContext, id);
                    keyboard = new InlineKeyboardMarkup(keyboardsFor.CreateKeyboardPeriods(periods));
                    await bot.SendTextMessageAsync(chatId: chatId, text: allMessages.ChoosePeriod(), replyMarkup: keyboard);
                }
            }
            else if (callbackQuery.Data.Contains("period_"))
            {
                parts=callbackQuery.Data.Split('_');
                int idPeriod = Convert.ToInt32(parts[1]);
                keyboard = new InlineKeyboardMarkup(keyboardsFor.CreateKeyboardPay(idPeriod));
                await bot.SendTextMessageAsync(chatId: chatId, allMessages.WellDonePay(), replyMarkup: keyboard);
            }
            else if (callbackQuery.Data.Contains("money_"))
            {
                parts= callbackQuery.Data.Split('_');
                int idPeriod= Convert.ToInt32(parts[1]);
                Period searched= databaseService.GetPeriod(_subsContext,idPeriod);
                var newUserPeriod = new UserPeriod
                {
                    MyUser = chatId,
                    PeriodId = idPeriod,
                    StatusId = 1,
                    StartDay=DateOnly.FromDateTime(DateTime.Today),
                    EndDay=DateOnly.FromDateTime(DateTime.Today.AddDays(searched.CountDays)),

                };
                _subsContext.UserPeriods.Add(newUserPeriod);
                _subsContext.SaveChanges();
                userPeriod = databaseService.GetUserPeriodByPeriod(_subsContext,idPeriod,chatId);
                keyboard = new InlineKeyboardMarkup(keyboardsFor.CreateKeyboardChangeStop(userPeriod));
                await bot.SendTextMessageAsync(chatId: chatId, allMessages.WellDonePayed(), replyMarkup: keyboard);

            }
            else if (callbackQuery.Data.Contains("stop_"))
            {
                parts = callbackQuery.Data.Split('_');
                id = Convert.ToInt32(parts[1]);
                userPeriod=databaseService.GetUserPeriodById(_subsContext,id);
                userPeriod.StatusId = 2;
                _subsContext.UserPeriods.Update(userPeriod);
                _subsContext.SaveChanges();
                await bot.SendTextMessageAsync(chatId: chatId, allMessages.ServiceStop());

            }
            else if (callbackQuery.Data.Contains("change_"))
            {
                parts = callbackQuery.Data.Split('_');
                id = Convert.ToInt32(parts[1]);
                userPeriod=databaseService.GetUserPeriodById(_subsContext, id);
                int idService = userPeriod.Period.ServiceSubsId;
                keyboard = new InlineKeyboardMarkup(keyboardsFor.CreateKeyboardServicesNew(idService));
                _subsContext.UserPeriods.Remove(userPeriod);
                _subsContext.SaveChanges();
                await bot.SendTextMessageAsync(chatId: chatId, allMessages.ChooseChangeService(), replyMarkup: keyboard);
            }

            await bot.AnswerCallbackQueryAsync(callbackQuery.Id, "Callback received");
        }

        [HttpGet]
        public string Get()
        {
            return "Телеграм бот начал работу";
        }

    }
}
