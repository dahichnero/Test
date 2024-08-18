using ServicesBot.Repositories.Realizations;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace ServicesBot.Controllers.Commands
{
    public class MenuCommand : ICommandss
    {
        public async Task Execute(ITelegramBotClient botClient, Message message)
        {
            AllMessages allMessages=new AllMessages();
            var keyboard = new ReplyKeyboardMarkup(new[]
            {
                new KeyboardButton("Сервисы"),
                new KeyboardButton("Личный кабинет")
            });
            await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: allMessages.LetsStart(), replyMarkup: keyboard);
        }
    }
}
