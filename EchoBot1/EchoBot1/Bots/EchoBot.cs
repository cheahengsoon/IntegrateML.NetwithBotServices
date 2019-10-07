// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
//
// Generated with Bot Builder V4 SDK Template for Visual Studio EchoBot v4.5.0

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EchoBot1ML.Model;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;
using Microsoft.ML;

namespace EchoBot1.Bots
{
    public class EchoBot : ActivityHandler
    {
        

        protected override async Task OnMessageActivityAsync(ITurnContext<IMessageActivity> turnContext, CancellationToken cancellationToken)
        {
            MLContext mlContext = new MLContext();
            ITransformer mlModel = mlContext.Model.Load(@"C:\Users\engsooncheah\source\repos\EchoBot1\EchoBot1ML.Model\MLModel.zip", out var modelInputSchema);
            var predEngine = mlContext.Model.CreatePredictionEngine<ModelInput, ModelOutput>(mlModel);

            var inputStr = turnContext.Activity.Text;
            
       
                var input = new ModelInput();
                input.Message = inputStr;
                ModelOutput result = predEngine.Predict(input);
                await turnContext.SendActivityAsync(MessageFactory.Text((Convert.ToBoolean(result.Prediction) ? "This is spam" : "Normal Message")));
             //  await turnContext.SendActivityAsync(MessageFactory.Text(Convert.ToBoolean(result.Prediction),cancellationToken);
  
           // await turnContext.SendActivityAsync(MessageFactory.Text($"Echo: {turnContext.Activity.Text}"), cancellationToken);
        }

        protected override async Task OnMembersAddedAsync(IList<ChannelAccount> membersAdded, ITurnContext<IConversationUpdateActivity> turnContext, CancellationToken cancellationToken)
        {
            foreach (var member in membersAdded)
            {
                if (member.Id != turnContext.Activity.Recipient.Id)
                {
                    await turnContext.SendActivityAsync(MessageFactory.Text($"Hello and welcome!"), cancellationToken);
                }
            }
        }



    }
}
