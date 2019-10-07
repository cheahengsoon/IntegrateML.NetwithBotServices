# Integrate ML.NET with Bot Services (Spam Message Detector on Sentiment Analysis)

## Reminder
* Change the Machine Learning Model reference path @ https://github.com/cheahengsoon/IntegrateML.NetwithBotServices/blob/master/EchoBot1/EchoBot1/Bots/EchoBot.cs

  **LINE 24**

 ```ITransformer mlModel = mlContext.Model.Load(@"C:\Users\engsooncheah\source\repos\EchoBot1\EchoBot1ML.Model\MLModel.zip", out var modelInputSchema);```
 
* Change the Data File reference path @ https://github.com/cheahengsoon/IntegrateML.NetwithBotServices/blob/master/EchoBot1/EchoBot1ML.ConsoleApp/Program.cs

  **LINE14**

 ```private const string DATA_FILEPATH = @"C:\Users\engsooncheah\Downloads\SMSSpamCollection.tsv";```
        
* Install ML.NET Model Builder https://dotnet.microsoft.com/apps/machinelearning-ai/ml-dotnet/model-builder
* BotBuilder SDK v4

