using PorusTestBot;
using Telegram.Bot;
using Telegram.Bot.Polling;

Console.WriteLine($"Bot has been started: {Brain.Bot.GetMeAsync().Result.FirstName}");

var cts = new CancellationTokenSource();
var cancellationToken = cts.Token;
var receiverOptions = new ReceiverOptions
{
	AllowedUpdates = { },
};

Brain.Bot.StartReceiving(
	Brain.HandleMessageAsync,
	Brain.HandleErrorAsync,
	receiverOptions,
	cancellationToken
);

Console.ReadLine();