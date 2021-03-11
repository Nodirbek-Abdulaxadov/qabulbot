using Microsoft.AspNetCore.Mvc;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace Qabul_Bot.Controllers
{
    public class HomeController : Controller
    {
        private TelegramBotClient client = new TelegramBotClient("1687855239:AAFeUvYrqt802BKieU1qf5m7caUmh4snRjY");
        ReplyKeyboardMarkup markup = new ReplyKeyboardMarkup();
        long userId = 0;
        public string Index()
        {
            client.OnMessage += Xabar_Kelganda;

            client.OnCallbackQuery += CallBack;

            client.StartReceiving();

            return "Your bot is working now";
        }
        public string kalit = "";
        private async void CallBack(object sender, CallbackQueryEventArgs e)
        {
            if (e.CallbackQuery.Data == "kurslar")
            {
                markup.Keyboard = new KeyboardButton[][]
                {
                    new KeyboardButton[]
                    {
                        new KeyboardButton("AKT savodxonligi 🖥"),
                    },
                    new KeyboardButton[]
                    {
                        new KeyboardButton(text: "C# 🔥"),
                        new KeyboardButton("C++ 📕")
                    },

                    new KeyboardButton[]
                    {
                        new KeyboardButton("Web dasturlash 🌐"),
                        new KeyboardButton("Python 🐍")
                    },
                    new KeyboardButton[]
                    {
                        new KeyboardButton("Rus tili 🇷🇺"),
                        new KeyboardButton("Ingliz tili 🏴󠁧󠁢󠁥󠁮󠁧󠁿")
                    },
                    new KeyboardButton[]
                    {
                        new KeyboardButton("Grafik dizayn 🖍"),
                        new KeyboardButton("Videomantaj 🎥")
                    },
                    new KeyboardButton[]
                    {
                        new KeyboardButton("3D Max 💎"),
                        new KeyboardButton("Robototexnika 🤖")
                    },
                    new KeyboardButton[]
                    {
                        new KeyboardButton("🔙 Orqaga"),
                    }
                };
                await client.SendTextMessageAsync(
                        chatId: e.CallbackQuery.Message.Chat.Id,
                        text: "Barcha kurslar",
                        replyMarkup: markup
                );
            }
            else if (e.CallbackQuery.Data == "admin")
            {
                await client.SendTextMessageAsync(
                    chatId: this.userId,
                    text: "<b>Raqamli Texnologiyalar Markaziga</b> <a href='https://t.me/nbkabdulaxadov2000'>Adminiga</a> murojaatingizni kiriting:",
                    parseMode: Telegram.Bot.Types.Enums.ParseMode.Html);
                kalit = "";
            } else if (e.CallbackQuery.Data == "info")
            {
                markup.Keyboard = new KeyboardButton[][]
               {
                    new KeyboardButton[]
                    {
                        new KeyboardButton("🔙 Orqaga"),
                    }
               };
                markup.ResizeKeyboard = true;
                await client.SendTextMessageAsync(
                        chatId: e.CallbackQuery.Message.Chat.Id,
                        text: "Markaz haqida",
                        replyMarkup: markup
                );
                await client.SendPhotoAsync(
                    chatId: this.userId,
                    photo: "http://www.mrtm.uz/imgs/about.jpg",
                    caption: "*RAQAMLI TEXNOLOGIYALAR MARKAZI*\n  Markaz maqsadi – Yoshlarni IT sohasiga " +
                    "bo‘lgan qiziqishlarini yanada oshirish xamda ularga ushbu yo‘nalishda chuqurroq bilim " +
                    "va ko‘nikmalar berish. Bir million o'zbek dasturchilari loyihasi doirasida IT mutaxassislar " +
                    "chiqarish. Texnopark binosi 120 dan ortiq ish o‘ringa mo‘ljallangan bo‘lib, 50 dan ortiq yangi " +
                    "axborot texnologiyalari sohasida xizmat ko‘rsatadigan korxonalarni joylashtirish uchun " +
                    "mo‘ljallangan. Mazkur Texnoparkda korxonalarga o‘z faoliyatini amalga oshirish uchun zarur " +
                    "infratuzilma, shu jumladan, zamonaviy laboratoriyalar, kovorking markaz hamda ofis maydonlari " +
                    "taqdim etilib, ularga raqamli texnologiyalar, marketing, yuridik va boshqa konsalting xizmatlari " +
                    "ko‘rsatiladi.",
                    parseMode: Telegram.Bot.Types.Enums.ParseMode.Markdown
                );
                kalit = "";
            }
        }
        private async void Xabar_Kelganda(object sender, MessageEventArgs e)
        {
            // foydalanuvchi idsi
            userId = e.Message.Chat.Id;
            // kelgan xabar idsi
            int msgId = e.Message.MessageId;
            // kelgan xabar
            string xabar = e.Message.Text.ToLower();

            /////////////     Start blog      /////////////////
            if (xabar == "/start")
            {
                await client.SendPhotoAsync(
                    chatId: e.Message.Chat.Id,
                    photo: "https://t.me/bbjnnvc/15",
                    caption: "*Assalomu alaykum!*\n*Raqamli Texnologiyalar Markazi* qabul botiga\n*Xush kelibsiz!*",
                    replyToMessageId: e.Message.MessageId,
                    parseMode: Telegram.Bot.Types.Enums.ParseMode.Markdown,
                    disableNotification: true
                );
                var markup = new InlineKeyboardMarkup(
                new InlineKeyboardButton[][]
                {
                    new InlineKeyboardButton[]
                    {
                        InlineKeyboardButton
                            .WithCallbackData(text: "Bizning kurslarimiz", callbackData: "kurslar"),
                        InlineKeyboardButton
                            .WithCallbackData(text: "Markaz haqida", callbackData: "info")
                    },
                    new InlineKeyboardButton[]
                    {
                        InlineKeyboardButton
                            .WithCallbackData(text: "Admin bilan aloqa", callbackData: "admin")
                    }
                    });
                await client.SendTextMessageAsync(
                        chatId: e.Message.Chat.Id,
                        text: "Mavjud imkoniyatlar 👇",
                        replyMarkup: markup
                        );
            }
            /////////////     Start blog      /////////////////


            /////////////     SELECT      /////////////////
            if (xabar == "🔙 orqaga")
            {
                await client.SendTextMessageAsync(
                    chatId: e.Message.Chat.Id,
                    text: "Orqaga",
                    replyMarkup: new ReplyKeyboardRemove());
                kalit = "";
                var markup = new InlineKeyboardMarkup(
                new InlineKeyboardButton[][]
                {
                    new InlineKeyboardButton[]
                    {
                        InlineKeyboardButton
                            .WithCallbackData(text: "Bizning kurslarimiz", callbackData: "kurslar"),
                        InlineKeyboardButton
                            .WithCallbackData(text: "Biz haqimizda", callbackData: "info")
                    },
                    new InlineKeyboardButton[]
                    {
                        InlineKeyboardButton
                            .WithCallbackData(text: "Admin bilan aloqa", callbackData: "admin")
                    }
                    });
                await client.SendTextMessageAsync(
                        chatId: e.Message.Chat.Id,
                        text: "Mavjud imkoniyatlar 👇",
                        replyMarkup: markup
                        );
            }
            if (xabar == "c# 🔥")
            {
                kalit = "c#";
            }
            else
            if (xabar.Contains("web"))
            {
                markup.Keyboard = new KeyboardButton[][]
                   {
                    new KeyboardButton[]
                    {
                        new KeyboardButton("🌕 Front-end"),
                        new KeyboardButton("🌑 Back-end"),
                    },
                    new KeyboardButton[]
                    {
                        new KeyboardButton("🔙 Orqaga")
                    }
                   };
                markup.ResizeKeyboard = true;
                await client.SendTextMessageAsync(
                        chatId: e.Message.Chat.Id,
                        text: "Web dasturlash",
                        replyMarkup: markup
                );
                kalit = "";
            }
            else
            if (xabar == "c++ 📕")
            {
                kalit = "c++";
            }
            else
            if (xabar == "akt savodxonligi 🖥")
            {
                kalit = "akt";
            }
            else
            if (xabar == "python 🐍")
            {
                kalit = "python";
            }
            else
            if (xabar == "rus tili 🇷🇺")
            {
                kalit = "rus";
            }
            else
            if (xabar == "ingliz tili 🏴󠁧󠁢󠁥󠁮󠁧󠁿")
            {
                kalit = "eng";
            }
            else
            if (xabar == "grafik dizayn 🖍")
            {
                kalit = "graf";
            }
            else
            if (xabar == "videomantaj 🎥")
            {
                kalit = "vid";
            }
            else
            if (xabar == "3d max 💎")
            {
                kalit = "3d";
            }
            else
            if (xabar.Contains("texnika"))
            {
                kalit = "R";
            }
            else
            if (xabar == "🌕 front-end")
            {
                kalit = "front";
            }
            else
            if (xabar.Contains("🌑 back-end"))
            {
                kalit = "main";
            }
            /////////////     SELECT      /////////////////

            /////////////     Info Blog      /////////////////
            if (kalit == "c#")
            {
                Message msg = await client.SendPhotoAsync(
                    chatId: e.Message.Chat.Id,
                    photo: "https://t.me/rtm_margilan/377",
                    caption: "💻 C# dasturlash tilida desktop ilovalar yaratish o'quv kursiga taklif etamizℹ️\n\n" +
                    "C# − bu oddiy, zamonaviy, umumiy maqsadli til bo'lib, u 2000 yilda Microsoft tomonidan ishlab" +
                    " chiqilgan va shu yildan buyon faol rivojlanib kelmoqda. \n\nHozirgi vaqtda unda turli xil dasturlar" +
                    " yozilgan.Kichik desktop dasturlaridan tortib to har kuni millionlab foydalanuvchilarga xizmat " +
                    "ko'rsatadigan yirik web portallar va xizmatlar, shuningdek mobil ilovalar va o'yinlar yaratish " +
                    "uchun ham ishlatiladi.\n\nBatafsil 👇👇👇\nhttps://telegra.ph/Nima-uchun-C-ni-organish-kerak-02-21\n\n⏱ 6 " +
                    "oylik kurs davomida siz C# dasturlash tilida kompyuter dasturlari yaratishni noldan boshlab o'rganasiz.\n\n" + "<a href='https://t.me/rtm_margilan'>🔹 Telegram kanalimiz</a>\n<a href='https://t.me/nbkabdulaxadov2000'>🔹 Mentor: Nodirbek</a>",

                    replyToMessageId: e.Message.MessageId,
                    parseMode: Telegram.Bot.Types.Enums.ParseMode.Html
                );
                kalit = "";
            }
            else
            if (kalit == "c++")
            {
                Message msg = await client.SendPhotoAsync(
                    chatId: e.Message.Chat.Id,
                    photo: "https://t.me/bbjnnvc/12",
                    caption: "📕 C++\n\n📚 Kurs haqida:\n📌 CodeBlocks\n📌 C++Builder Embarcadero RAD Studio XE7\n" +
                    "\n📚 Kurs afzalligi: Desktop dasturlarni tuza oladi. Savdo - sotiq tizimlarini avtomatlashtirish. " +
                    "O'yinlar tuzishni, Sekundomer, MediaPlayer, Calculator, Bloknot va boshqa qiziqarli dasturlarni " +
                    "tuzishni o'rganasiz.\n\n<a href='https://t.me/rtm_margilan'>🔹 Telegram kanalimiz</a>\n<a href='http://t.me/Umidjon_Uktamov'>🔹 Mentor</a>",
                    replyToMessageId: e.Message.MessageId,
                    parseMode: Telegram.Bot.Types.Enums.ParseMode.Html
                );
                kalit = "";
            }
            else
            if (kalit == "akt")
            {
                Message msg = await client.SendPhotoAsync(
                    chatId: e.Message.Chat.Id,
                    photo: "https://t.me/bbjnnvc/2",
                    caption: "💻 AKT Savodxonligi\n\n📚 Kurs haqida:\n📌 Texnik ta'minot\n📌 Dasturiy ta'minot" +
                    "\n📌 Microsoft Office dasturlari(Word | Excel | Powerpoint)\n\n📚 Kurs afzalligi: " +
                    "Kompyuternimg ichki tuzilishi haqida ma'lumotlar, OS va Driverlar haqida to'liq ma'lumot. " +
                    "Kompyuterda Microsoft Office dasturlarida qiynalmasdan fayllar tuzish.\n" +
                    "\n<a href='https://t.me/rtm_margilan'>🔹 Telegram kanalimiz</a>\n<a href='http://t.me/Mc_Tim'>🔹 Mentor</a>",
                    replyToMessageId: e.Message.MessageId,
                    parseMode: Telegram.Bot.Types.Enums.ParseMode.Html
                );
                kalit = "";
            }
            else
            if (kalit == "python")
            {
                Message msg = await client.SendPhotoAsync(
                    chatId: e.Message.Chat.Id,
                    photo: "https://t.me/bbjnnvc/5",
                    caption: "🐍 Python\n\n📚 Kurs haqida:\n📌 Operatorlar\n📌 Funksiyalar\n📌 Fayllar bilan ishlash" +
                    "\n📌 Flask Framework\n" +
                    "\n<a href='https://t.me/rtm_margilan'>🔹 Telegram kanalimiz</a>\n<a href='http://t.me/RtmPython'>🔹 Mentor</a>",
                    replyToMessageId: e.Message.MessageId,
                    parseMode: Telegram.Bot.Types.Enums.ParseMode.Html
                );
                kalit = "";
            }
            else
            if (kalit == "rus")
            {
                Message msg = await client.SendPhotoAsync(
                    chatId: e.Message.Chat.Id,
                    photo: "https://t.me/bbjnnvc/6",
                    caption: "🇷🇺 Rus tili\n\n📚 Kurs haqida:\n📌 Rus tili grammatikasi" +
                    "\n📌 Rus tili so’zlashuvi\n📌 Rus tilida ravon gapira olish\n" +
                    "\n<a href='https://t.me/rtm_margilan'>🔹 Telegram kanalimiz</a>\n<a href='http://t.me/poshsha0696'>🔹 Mentor</a>",
                    replyToMessageId: e.Message.MessageId,
                    parseMode: Telegram.Bot.Types.Enums.ParseMode.Html
                );
                kalit = "";
            }
            else
            if (kalit == "eng")
            {
                Message msg = await client.SendPhotoAsync(
                    chatId: e.Message.Chat.Id,
                    photo: "https://t.me/bbjnnvc/7",
                    caption: "🇺🇸 Ingliz tili\n\n📚 Kurs haqida:\n📌 Elementary\n📌 Pre - Intermediate" +
                    "\n📌 Intermediate\n📌 Upper - Intermediate\n📌 Advanced\n\n📚 Kurs afzalligi: Ingliz tilida " +
                    "ravon gaplashish.Grammatikani mukammal tarzda o'rgatiladi. IELTS ga tayyorgarlik. Ingliz tilini " +
                    "Lingo master va RTM bilan birgalikda o'rganing.😉\n" +
                    "\n<a href='https://t.me/rtm_margilan'>🔹 Telegram kanalimiz</a>\n<a href='http://t.me/miss_zoda18'>🔹 Mentor: Gulzoda</a>\t" +
                    "<a href='http://t.me/IamShojalilovN'>🔹 Mentor: Nodir</a>",
                    replyToMessageId: e.Message.MessageId,
                    parseMode: Telegram.Bot.Types.Enums.ParseMode.Html
                );
                kalit = "";
            }
            else
            if (kalit == "graf")
            {
                Message msg = await client.SendPhotoAsync(
                    chatId: e.Message.Chat.Id,
                    photo: "https://t.me/bbjnnvc/8",
                    caption: "🖋 Grafik dizayn\n\n📚 Kurs haqida:\n📌 Photoshop\n📌 Illustrator" +
                    "\n📌 SMM\n📌 UI / UX\n📌 Dizayn mahorati\n📌 Animatsiyalar\n" +
                    "\n<a href='https://t.me/rtm_margilan'>🔹 Telegram kanalimiz</a>\n<a href='http://t.me/Alidizayner'>🔹 Mentor</a>",
                    replyToMessageId: e.Message.MessageId,
                    parseMode: Telegram.Bot.Types.Enums.ParseMode.Html
                );
                kalit = "";
            }
            else
            if (kalit == "vid")
            {
                Message msg = await client.SendPhotoAsync(
                    chatId: e.Message.Chat.Id,
                    photo: "https://t.me/bbjnnvc/9",
                    caption: "🎥 Videomontaj\n\n📚 Kurs haqida:\n📌 PremierePro\n📌 After Effects" +
                    "\n📌 SMM\n📌 Ijtimoiy tarmoqlarga mos videolar yaratish\n📌 Animatsiyalar\n" +
                    "\n<a href='https://t.me/rtm_margilan'>🔹 Telegram kanalimiz</a>\n<a href='http://t.me/thedioraka'>🔹 Mentor</a>",
                    replyToMessageId: e.Message.MessageId,
                    parseMode: Telegram.Bot.Types.Enums.ParseMode.Html
                );
                kalit = "";
            }
            else
            if (kalit == "3d")
            {
                Message msg = await client.SendPhotoAsync(
                    chatId: e.Message.Chat.Id,
                    photo: "https://t.me/bbjnnvc/10",
                    caption: "💎 3D Max\n\n📚 Kurs haqida:\n📌 Komyuterda 3 o’lchovli grafika" +
                    "\n📌 3D MAX\n📌 Modellarni xalqaro platformalarda sotish\n" +
                    "\n<a href='https://t.me/rtm_margilan'>🔹 Telegram kanalimiz</a>\n<a href='http://t.me/abdul_9800'>🔹 Mentor</a>",
                    replyToMessageId: e.Message.MessageId,
                    parseMode: Telegram.Bot.Types.Enums.ParseMode.Html
                );
                kalit = "";
            }
            else
            if (kalit == "R")
            {
                Message msg = await client.SendPhotoAsync(
                    chatId: e.Message.Chat.Id,
                    photo: "https://t.me/bbjnnvc/11",
                    caption: "🤖 Robototexnika\n\n📚 Kurs haqida:\n📌 Elektronika\n" +
                    "📌 Dasturlash asoslari\n📌 Arduino platasida dasturlash\n" +
                    "\n<a href='https://t.me/rtm_margilan'>🔹 Telegram kanalimiz</a>\n<a href='http://t.me/MargilonR'>🔹 Mentor</a>",
                    replyToMessageId: e.Message.MessageId,
                    parseMode: Telegram.Bot.Types.Enums.ParseMode.Html
                );
                kalit = "";
            }
            else
            if (kalit == "front")
            {
                Message msg = await client.SendPhotoAsync(
                    chatId: e.Message.Chat.Id,
                    photo: "https://t.me/bbjnnvc/13",
                    caption: "🌕 Front-end\n\n📚 Kurs haqida:\n📌 HMTL\n📌 CSS" +
                    "\n📌 Bootstrap\n📌 JavaScript\n\n📚 Kurs afzalligi: Saytlar interfeysini " +
                    "tuzish va ularni hostinglarga joylash.Qo'shimcha UI/UX dizaynerlikdan ham qo'shimcha ma'lumotlar beriladi.\n" +
                    "\n<a href='https://t.me/rtm_margilan'>🔹 Telegram kanalimiz</a>\n<a href='http://t.me/sanjar_8855'>🔹 Mentor: Sanjar</a>\t" +
                    "<a href='http://t.me/ussardor'>🔹 Mentor: Sardor</a>",
                    replyToMessageId: e.Message.MessageId,
                    parseMode: Telegram.Bot.Types.Enums.ParseMode.Html
                );
                kalit = "";
            }
            else
            if (kalit == "main")
            {
                Message msg = await client.SendPhotoAsync(
                    chatId: e.Message.Chat.Id,
                    photo: "https://t.me/bbjnnvc/14",
                    caption: "🌑 Back-end\n\n📚 Kurs haqida:\n📌 PHP\n📌 COMPOSER\n📌 RestAPI" +
                    "\n📌 SQL(MySQL, SQLlite3)\n📌 phpmyadmin\n\n📚 Kurs afzalligi: Kurs WEB dasturchi " +
                    "bo'lib chiqadi. undan tashqari bazalar bilan ishlash mukammal o'rgatiladi. " +
                    "Full - stack WEB developer maqomini ham oladi.\n" +
                    "\n<a href='https://t.me/rtm_margilan'>🔹 Telegram kanalimiz</a>\n<a href='http://t.me/sanjar_8855'>🔹 Mentor</a>",
                    replyToMessageId: e.Message.MessageId,
                    parseMode: Telegram.Bot.Types.Enums.ParseMode.Html
                );
                kalit = "";
            }
            //if(kalit == "")
            /////////////     Info Blog      /////////////////
        }
    }
}
