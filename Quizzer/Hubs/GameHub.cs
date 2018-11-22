using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.FSharp.Core;
using Quizzer.Domain;

namespace Quizzer.Hubs
{
    public class GameHub : Hub
    {
        private readonly GameHandler gameHandler;

        public GameHub(GameHandler gameHandler)
        {
            this.gameHandler = gameHandler;
        }

        public async Task Join(Guid gameId, string playerName)
        {
            var typedGameId = GameId.NewGameId(gameId);
            var joinEvent = Game.join(playerName);
            gameHandler.Handle(typedGameId, joinEvent);
            await Clients.Caller.SendAsync("newQuestion", new
            {
                targetPlayerName = "<name>",
                text = ((DomainTypes.Question.SingleAnswerQuestion)gameHandler.GetCurrentQuestion(typedGameId)).Item.Text
            });
        }

        public async Task ProvideAnswer(Guid gameId)
        {
            var typedGameId = GameId.NewGameId(gameId);
            var question = ((DomainTypes.Question.SingleAnswerQuestion) gameHandler.GetCurrentQuestion(typedGameId)).Item;
            await Clients.All.SendAsync("questionAnswered", new
            {
                targetPlayerId = gameHandler.GetCurrentTargetPlayer(typedGameId),
                text = question.Text,
                options = question.Options.Select(option => new { text = option.Value.Text, id = option.Key }).ToArray(),
                answers = new []
                {
                    new
                    {
                        optionId = Guid.Empty,
                        playerId = Guid.Empty
                    }
                }
            });
        }
    }

    public class GameHandler
    {
        private readonly Dictionary<GameId, DomainTypes.Game> games = new Dictionary<GameId, DomainTypes.Game>();

        public GameHandler()
        {
            var gameCreatedEvent = Game.create(new[]
            {
                SingleAnswerQuestion.create("What is my favorite color?", new[] {"Red", "Green", "Blue"}),
                MultipleAnswerQuestion.create("What is my favorite color?", new[] { "Red", "Green", "Blue", "Yellow" })
            });

            Handle(gameCreatedEvent);

            var philipJoinedEvent = Game.join("Philip S");
            var emilJoinedEvent = Game.join("Emil S");

            Handle(gameCreatedEvent.GameId, philipJoinedEvent);
            Handle(gameCreatedEvent.GameId, emilJoinedEvent);

            var philipAnswerQuestionEvent = Game.answerQuestion(TempGetGame(), ((GameEvent.PlayerJoinedEvent)philipJoinedEvent).Item.PlayerId,
                DomainTypes.Answer.NewSingleAnswer(new DomainTypes.SingleAnswer(
                    ((DomainTypes.Question.SingleAnswerQuestion)TempGetGame().Questions.First().Value).Item.Options.First().Key)));

            if (philipAnswerQuestionEvent?.Value != null)
            {
                Handle(gameCreatedEvent.GameId, philipAnswerQuestionEvent.Value);
            }
        }

        public void Handle(GameCreatedEvent @event)
        {
            var game = GameBuilder.build(@event);
            games.Add(@event.GameId, game);
        }

        public void Handle(GameId gameId, GameEvent @event)
        {
            var currentGameState = games[gameId];
            games[gameId] = GameBuilder.apply(currentGameState, @event);
        }

        private DomainTypes.Game TempGetGame()
        {
            return games.First().Value;
        }

        public DomainTypes.Question GetCurrentQuestion(GameId gameId)
        {
            return games[gameId].Questions[games[gameId].CurrentQuestionId];
        }

        public PlayerId GetCurrentTargetPlayer(GameId gameId)
        {
            return PlayerId.NewPlayerId(Guid.Empty);
        }
    }
}
