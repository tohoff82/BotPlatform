﻿using System;
using System.Linq;
using System.Collections.Generic;
using BotPlatform.ServerLogic;
using System.Threading.Tasks;

namespace BotPlatform.Cryptohacker
{
    public class ChatAnswer
    {
        private List<string> maleAnswersToBotUa;
        private List<string> femaleAnswersToBotUa;
        private List<string> maleAnswersToBotRu;
        private List<string> femaleAnswersToBotRu;

        private List<string> maleCalledAnswersUa;
        private List<string> femaleCalledAnswersUa;
        private List<string> maleCalledAnswersRu;
        private List<string> femaleCalledAnswersRu;

        private List<string> defaultAnswersUa;
        private List<string> defaultAnswersRu;

        public ChatAnswer()
        {
            maleAnswersToBotUa = new List<string>();
            femaleAnswersToBotUa = new List<string>();
            maleAnswersToBotRu = new List<string>();
            femaleAnswersToBotRu = new List<string>();

            maleCalledAnswersUa = new List<string>();
            femaleCalledAnswersUa = new List<string>();
            maleCalledAnswersRu = new List<string>();
            femaleCalledAnswersRu = new List<string>();

            defaultAnswersUa = new List<string>();
            defaultAnswersRu = new List<string>();

            FillAnswers();
        }

        #region Block Fill Answers
        //Варианты сценариев ответа
        private void FillAnswers()
        {
            FillBotAnswersUa();
            FillBotAnswersRu();

            FillCalledAnswersUa();
            FillCalledAnswersRu();

            FillDefaultAnswers();
        }


        private void FillBotAnswersUa()
        {
            //Male
            maleAnswersToBotUa.Add(" Гей, ковбоє, полегше...");
            maleAnswersToBotUa.Add(" Воув, хлопче, не так швидко...");
            maleAnswersToBotUa.Add(" І що це ти написав?");

            //Female
            femaleAnswersToBotUa.Add(" Гей, кралечко, полегше...");
            femaleAnswersToBotUa.Add(" Воув, дівонька, не так швидко...");
            femaleAnswersToBotUa.Add(" І що це ти написала?");
        }

        private void FillBotAnswersRu()
        {
            //Male
            maleAnswersToBotRu.Add(" Эй, дружище, полегче...");
            maleAnswersToBotRu.Add(" Парниша, не так быстро...");
            maleAnswersToBotRu.Add(" И что это ты написал?");

            //Female
            femaleAnswersToBotRu.Add(" Симпатюля, полегче...");
            femaleAnswersToBotRu.Add(" Слишком много букв...");
            femaleAnswersToBotRu.Add(" И что это ты написала?");
        }


        private void FillCalledAnswersUa()
        {
            //Male
            maleCalledAnswersUa.Add(", ти мене кликав?");
            maleCalledAnswersUa.Add(", це ти до мене?");
            maleCalledAnswersUa.Add(", потрібна допомога?");

            //Female
            femaleCalledAnswersUa.Add(", ти мене кликала?");
            femaleCalledAnswersUa.Add(", це ти до мене?");
            femaleCalledAnswersUa.Add(", потрібна допомога?");
        }

        private void FillCalledAnswersRu()
        {
            //Male
            maleCalledAnswersRu.Add(", ты меня звал?");
            maleCalledAnswersRu.Add(", ты ко мне?");
            maleCalledAnswersRu.Add(", нужна помощь?");

            //Female
            femaleCalledAnswersRu.Add(", ти меня звала?");
            femaleCalledAnswersRu.Add(", ты ко мне?");
            femaleCalledAnswersRu.Add(", нужна помощь?");
        }


        private void FillDefaultAnswers()
        {
            defaultAnswersUa.Add(" Мій штучний інтелект ще не на стільки розумний щоб тебе зрозуміти...");
            defaultAnswersUa.Add(" Твоя писанина спалила мій процессор...");
            defaultAnswersUa.Add(" Мій мозок закипів від твоєї писанини...");

            defaultAnswersRu.Add(" Мой искуственный интеллект тебя не понял...");
            defaultAnswersRu.Add(" Не могу тебя понять...");
            defaultAnswersRu.Add(" Не могу понять, что это написано...");
        }


        private int Rnd(List<string> answList)
        {
            Random rnd = new Random();
            return rnd.Next(answList.Count);
        }

        private string GetBotPic(string botPic)
        {
            switch (botPic)
            {
                case "max": return "🤖 ";
                case "mark": return "👨‍🎓 ";
                default: return "";
            }
        }
        #endregion

        #region PictoBots --> Wrog Write
        //Логика ответа ПиктоБотов на непонятный ввод
        public string GetAfterWrongWriteAnswer(string gender, string botPic)
        {
            switch (botPic)
            {
                case "max":
                    {
                        if (gender == "male")
                            return BotSerializer.SendText(GetBotPic(botPic) + maleAnswersToBotUa.ElementAt(Rnd(maleAnswersToBotUa)));
                        else return BotSerializer.SendText(GetBotPic(botPic) + femaleAnswersToBotUa.ElementAt(Rnd(femaleAnswersToBotUa)));
                    }
                case "mark":
                    {
                        if (gender == "male")
                            return BotSerializer.SendText(GetBotPic(botPic) + maleAnswersToBotRu.ElementAt(Rnd(maleAnswersToBotRu)));
                        else return BotSerializer.SendText(GetBotPic(botPic) + femaleAnswersToBotRu.ElementAt(Rnd(femaleAnswersToBotRu)));
                    }
                default: return BotSerializer.SendText(GetBotPic(botPic) + " ???");
            }
        }
        #endregion

        #region PictoBots --> Appeal as
        //Логика ответа Пиктоботов на обращение к ним
        public string GetAfterBotsAppealAnswer(string gender, string usrName, string botPic)
        {
            switch(botPic)
            {
                case "max":
                    {
                        if (gender == "male")
                            return BotSerializer.SendText(GetBotPic(botPic) + usrName + maleCalledAnswersUa.ElementAt(Rnd(maleCalledAnswersUa)));
                        else
                            return BotSerializer.SendText(GetBotPic(botPic) + usrName + femaleCalledAnswersUa.ElementAt(Rnd(femaleCalledAnswersUa)));
                    }
                case "mark":
                    {
                        if (gender == "male")
                            return BotSerializer.SendText(GetBotPic(botPic) + usrName + maleCalledAnswersRu.ElementAt(Rnd(maleCalledAnswersRu)));
                        else
                            return BotSerializer.SendText(GetBotPic(botPic) + usrName + femaleCalledAnswersRu.ElementAt(Rnd(femaleCalledAnswersRu)));
                    }
                default: return BotSerializer.SendText(GetBotPic(botPic) + "????");
            }
        }

        #endregion

        #region Default Answer
        //Логтка ответа если на вопрос макса вбита какая-то лобуда...
        public string GetDefaultAnswer(string blockId, string botPic)
        {
            switch (blockId)
            {
                case "main-menu-blck":
                    {
                        if (botPic == "mark") return BotSerializer.SendText(GetBotPic(botPic) + " Просто введи \"ДА\" или \"НЕТ\" ");
                        else return BotSerializer.SendText(GetBotPic(botPic) + " Просто введи \"ТАК\" або \"НІ\" ");
                    };
                case "max-yes-no": return BotSerializer.SendText(GetBotPic(botPic) + " Відповіси \"ТАК\" або \"НІ\" ");
                case "mark-yes-no": return BotSerializer.SendText(GetBotPic(botPic) + " Ответь \"ДА\" или \"НЕТ\" ");
                default:
                    {
                        if (botPic== "mark") return BotSerializer.SendText(GetBotPic(botPic) + defaultAnswersRu.ElementAt(Rnd(defaultAnswersUa)));
                        else return BotSerializer.SendText(GetBotPic(botPic) + defaultAnswersUa.ElementAt(Rnd(defaultAnswersUa)));
                    }
            }
        }

        #endregion

        #region Timestamp

        public string GetTimestamp(string timestamp)
        {
            return BotSerializer.SendText("Час на сервері: " + timestamp);
        }

        #endregion

        #region Currensys
        public string GetCurrensy(string marketPair, string currValue)
        {
            return BotSerializer.SendText("📈 " + marketPair.ToUpper() + ": " + currValue + " UAH");
        }
        #endregion
    }
}
