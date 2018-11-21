using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Quizzer.Domain;

namespace Quizzer.Hubs
{
    public class GameHub : Hub
    {
        private readonly List<object> events = new List<object>();

        public GameHub()
        {
            var gameCreatedEvent = Game.create;
            events.Add(gameCreatedEvent);

            var addSingleQuestionEvent = Game.addQuestion(gameCreatedEvent.GameId, SingleAnswerQuestion.create("What is my favorite color?", new[] {"Red", "Green", "Blue"}));
            events.Add(addSingleQuestionEvent);
            events.Add(Game.addQuestion(gameCreatedEvent.GameId, MultipleAnswerQuestion.create("What is my favorite color?", new[] { "Red", "Green", "Blue", "Yellow" })));

            var philipJoinedEvent = Game.join(gameCreatedEvent.GameId, "Philip");
            events.Add(philipJoinedEvent);
            events.Add(Game.join(gameCreatedEvent.GameId, "Emil"));

            events.Add(Game.answerQuestion(gameCreatedEvent.GameId, philipJoinedEvent.PlayerId, new DomainTypes.Answer.SingleAnswer(new DomainTypes.SingleAnswer(addSingleQuestionEvent.QuestionData))));
        }

        public async Task ProvideAnswer(string tampId)
        {
            await Clients.All.SendAsync("newQuestion", "tamp text");
        }
    }
}
