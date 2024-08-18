

using ServicesBot.Models;
using ServicesBot.Repositories.Realizations;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace ServiceBotTest
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class Tests
    {

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        [Test]
        public void CheckDate()
        {
            DateEx dateEx = new DateEx();
            DateOnly dateOnly= new DateOnly(2024,8,25);
            int exception = 7;
            int res=dateEx.DateMinus(dateOnly);
            Assert.AreEqual(exception, res);
        }

        [Test]
        public void CheckWrongDate()
        {
            DateEx dateEx = new DateEx();
            DateOnly dateOnly = new DateOnly(2023, 8, 25);
            int exception = -359;
            int res = dateEx.DateMinus(dateOnly);
            Assert.AreEqual(exception, res);
        }

        [Test]
        public void TestDate()
        {
            DateEx dateEx = new DateEx();
            DateOnly dateOnly = new DateOnly(2024, 8,18);
            int exception = 0;
            int res=dateEx.DateMinus(dateOnly);
            Assert.AreEqual(exception, res);
        }

        [Test]
        public void TestInfo()
        {
            AllMessages allMessages = new AllMessages();
            ServiceSubs serviceSubs = new ServiceSubs
            {
                ServiceName = "Spotify",
                ServiceSubsId = 1
            };
            Period period = new Period
            {
                PeriodId=2,
                Price = 200,
                CountDays=30,
                ServiceSubs=serviceSubs,
                Detail="На месяц"
            };
            Status status =new Status
            {
                StatusId=1,
                StatusName="Включена"
            };


            UserPeriod newUserPeriod = new UserPeriod
            {
                MyUser = 1,
                Period = period,
                StatusId = 1,
                StartDay = DateOnly.FromDateTime(DateTime.Today),
                EndDay = DateOnly.FromDateTime(DateTime.Today.AddDays(period.CountDays)),
                Status=status,

            };
            
            string res=allMessages.InfoAbout(newUserPeriod);
            string ex = "Spotify Статус: Включена Осталось дней: 30 Ссылка на бота: https://telegrambot.fake\n";
            Assert.AreEqual (ex,res);
            
        }

        [Test]
        public void TestInfoWrong()
        {
            AllMessages allMessages = new AllMessages();
            ServiceSubs serviceSubs = new ServiceSubs
            {
                ServiceName = "Spotify",
                ServiceSubsId = 1
            };
            Period period = new Period
            {
                PeriodId = 2,
                Price = 200,
                CountDays = 30,
                ServiceSubs = serviceSubs,
                Detail = "На месяц"
            };
            Status status = new Status
            {
                StatusId = 1,
                StatusName = "Включена"
            };


            UserPeriod newUserPeriod = new UserPeriod
            {
                MyUser = 1,
                Period = period,
                StatusId = 1,
                StartDay = DateOnly.FromDateTime(DateTime.Today),
                EndDay = DateOnly.FromDateTime(DateTime.Today.AddDays(period.CountDays)),
                Status = status,

            };

            string res = allMessages.InfoAbout(newUserPeriod);
            string ex = "Spotify Статус: Включена Осталось дней: 20 Ссылка на бота: https://telegrambot.fake\n";
            Assert.AreNotEqual(ex, res);

        }

        [Test]
        public void KeyboardsTest()
        {
            KeyboardsFor keyboardsFor = new KeyboardsFor();
            UserPeriod userPeriod = new UserPeriod
            {
                Id=1,
            };
            InlineKeyboardMarkup res = new InlineKeyboardMarkup(keyboardsFor.CreateKeyboardChangeStop(userPeriod));
            var buttons = res.InlineKeyboard.ToArray();
            Assert.NotNull( buttons );
            Assert.AreEqual(2, buttons[0].Count());

        }

        [Test]
        public void KeyBoardTest1()
        {
            KeyboardsFor keyboardsFor = new KeyboardsFor();
            int periodId = 1;
            InlineKeyboardMarkup res = new InlineKeyboardMarkup(keyboardsFor.CreateKeyboardPay(periodId));
            var buttons = res.InlineKeyboard.ToArray();
            Assert.NotNull(buttons);
            Assert.AreEqual(1, buttons[0].Count());
        }

        [Test]
        public void KeyBoardTest2()
        {
            KeyboardsFor keyboardsFor = new KeyboardsFor();
            UserPeriod userPeriod = new UserPeriod
            {
                Id=1,
            };
            InlineKeyboardMarkup res = new InlineKeyboardMarkup(keyboardsFor.CreateKeyboardRestart(userPeriod));
            var buttons = res.InlineKeyboard.ToArray();
            Assert.NotNull(buttons);
            Assert.AreEqual(1, buttons[0].Count());
        }

        [Test]
        public void KeyBoardTest3()
        {
            KeyboardsFor keyboardsFor = new KeyboardsFor();
            int idServices = 1;
            InlineKeyboardMarkup res = new InlineKeyboardMarkup(keyboardsFor.CreateKeyboardServicesNew(idServices));
            var buttons = res.InlineKeyboard.ToArray();
            Assert.NotNull(buttons);
            Assert.AreEqual(1, buttons[0].Count());
        }

        [Test]
        public void KeyBoardTest4()
        {
            KeyboardsFor keyboardsFor = new KeyboardsFor();
            List<ServiceSubs> serviceSubs=new List<ServiceSubs>
            {
                new ServiceSubs
                {
                    ServiceName="Spotify",
                    ServiceSubsId=1,
                },
                new ServiceSubs
                {
                    ServiceName="Yandex",
                    ServiceSubsId=2,
                }
            };
            InlineKeyboardMarkup res = new InlineKeyboardMarkup(keyboardsFor.CreateKeyboardServices(serviceSubs));
            var buttons = res.InlineKeyboard.ToArray();
            Assert.NotNull(buttons);
            Assert.AreEqual(2, buttons.Count());
        }

        [Test]
        public void KeyBoardTest5()
        {
            KeyboardsFor keyboardsFor = new KeyboardsFor();
            List<Period> serviceSubs = new List<Period>
            {
                new Period
                {
                    Detail="На 2 месяца",
                    PeriodId=1,
                    Price=200
                },
                new Period
                {
                    Detail="На 4 месяца",
                    PeriodId=2,
                    Price=500
                },
                new Period
                {
                    Detail="На год",
                    PeriodId=3,
                    Price=800
                },
            };
            InlineKeyboardMarkup res = new InlineKeyboardMarkup(keyboardsFor.CreateKeyboardPeriods(serviceSubs));
            var buttons = res.InlineKeyboard.ToArray();
            Assert.NotNull(buttons);
            Assert.AreEqual(3, buttons.Count());
        }
    }
}
