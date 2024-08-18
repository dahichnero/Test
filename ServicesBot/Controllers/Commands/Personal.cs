using Microsoft.EntityFrameworkCore;
using ServicesBot.Models;
using ServicesBot.Repositories.Realizations;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ServicesBot.Controllers.Commands
{
    public class Personal : ICommandss
    {
        private ServicesSubsContext _subsContext;

        public Personal(ServicesSubsContext subsContext)
        {
            _subsContext = subsContext;
        }

        public async Task Execute(ITelegramBotClient botClient, Message message)
        {
            AllMessages allMessages = new AllMessages();
            DatabaseService databaseService=new DatabaseService();
            var keyboard = new ReplyKeyboardMarkup(new[]
            {
                new KeyboardButton("Назад в главное меню")
            });
            string forYou = "";

            List<UserPeriod> userPeriods = databaseService.GetUserPeriods(_subsContext, message.From.Id);
            if (userPeriods.Count==0)
            {
                await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: allMessages.OhSorry(), replyMarkup: keyboard);
            }

            else
            {
                foreach (var userPeriod in userPeriods)
                {
                    forYou += allMessages.InfoAbout(userPeriod);
                }
                await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: forYou, replyMarkup: keyboard);
            }

        }
    }
}
