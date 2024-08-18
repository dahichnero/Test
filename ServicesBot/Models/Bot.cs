using Telegram.Bot;

namespace ServicesBot.Models
{
    public class Bot
    {
        private static TelegramBotClient client { get; set; }

        public static TelegramBotClient GetTelegramBotClient()
        {
            if (client != null)
            {
                return client;
            }
            client = new TelegramBotClient("7103996505:AAE0HqDfoB-np5eaoEsLvDhydB7PGf9yEvU");
            return client;
        }
    }
}
