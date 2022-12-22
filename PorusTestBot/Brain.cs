using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Newtonsoft.Json;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace PorusTestBot
{
	class Brain
	{
		public static ITelegramBotClient Bot { get; set; } =
				new TelegramBotClient("5917682800:AAFLlyv8HiTLYMuamF3UGgzmpWU5rtgUgpM");


		public static async Task HandleMessageAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
		{
			DBCommand dbCommand = new();

			Console.WriteLine(JsonConvert.SerializeObject(update));

			if (update.Type == Telegram.Bot.Types.Enums.UpdateType.Message)
			{
				var message = update.Message;

				if (message.Text != null)
				{

					if (message.Text.ToLower() == "/start")
					{
						ReplyKeyboardMarkup replyKeyboard = new(new[]
						{
							new KeyboardButton[] { "Регистрация" }
						})
						{
							ResizeKeyboard = true
						};

						await botClient.SendTextMessageAsync(message.Chat.Id, "Приветики :)", replyMarkup: replyKeyboard);
						return;
					}

					if (message.Text.ToLower() == "регистрация")
					{
						await botClient.SendTextMessageAsync(message.Chat.Id, "Введите фамилию и имя", parseMode: default, replyMarkup: new ForceReplyMarkup
						{
							Selective = true
						});
						return;
					}

					if (message.ReplyToMessage!=null && message.ReplyToMessage.Text.Contains("Введите фамилию и имя"))
					{
						string[] tempString = message.Text.Split(new char[] { ' ' });
						string lastName ="" ;
						string firstName="";

						int i = 0;
						foreach (string s in tempString)
						{
							if (i == 0)
							{
								lastName=s;
								i++;
							}
							else
								firstName=s;
						}


						await dbCommand.AddNewUserAsync(message.From.Id, firstName, lastName);
						
						await botClient.SendTextMessageAsync(message.Chat.Id, "Регистрация успешна");
					}
				}
				return;
			}

		}

		public static async Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            Console.WriteLine(JsonConvert.SerializeObject(exception));
        }

	}
}
