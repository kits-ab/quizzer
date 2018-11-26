using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Quizzer.Domain;
using Quizzer.Services;
using Quizzer.Services.Client;
using Quizzer.Services.Game;

namespace Quizzer.Hubs
{
    public class GameHub : Hub
    {
        private const string GameGroupName = "game";
        private const string ClientGroupName = "client";

        private readonly GameStateDenormalizer gameStateDenormalizer;
        private readonly ClientStateDenormalizer clientStateDenormalizer;
        private readonly EventStore eventStore;
        private readonly GameRepository gameRepository;

        public GameHub(GameStateDenormalizer gameStateDenormalizer, ClientStateDenormalizer clientStateDenormalizer, EventStore eventStore, GameRepository gameRepository)
        {
            this.gameStateDenormalizer = gameStateDenormalizer;
            this.clientStateDenormalizer = clientStateDenormalizer;
            this.eventStore = eventStore;
            this.gameRepository = gameRepository;
        }

        public async Task Create()
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, GameGroupName);
            var gameId = GameId.NewGameId(Guid.NewGuid());
            eventStore.Add(gameId, Game.addQuestion(SingleAnswerQuestion.create("What is my favorite color?", new[] { "Red", "Green", "Blue" })));
            eventStore.Add(gameId, Game.addQuestion(MultipleAnswerQuestion.create("What is my favorite color?", new[] { "Red", "Green", "Blue", "Yellow" })));
            await Clients.All.SendAsync("newGame", gameId.Item);
            await SendNewState(gameId);
        }

        public async Task Join(Guid gameId, string playerName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, ClientGroupName);
            var typedGameId = GameId.NewGameId(gameId);
            var joinEvent = Game.join(playerName);
            eventStore.Add(typedGameId, joinEvent);
            await Clients.Caller.SendAsync("newPlayer", ((GameEvent.PlayerJoinedEvent) joinEvent).Item.PlayerId.Item);
            await SendNewState(typedGameId);
        }

        public async Task ProvideSingleAnswer(Guid gameId, Guid playerId, Guid optionId)
        {
            var typedGameId = GameId.NewGameId(gameId);

            var game = gameRepository.GetById(typedGameId);
            var answerEvent = Game.answerQuestion(
                game,
                PlayerId.NewPlayerId(playerId),
                DomainTypes.Answer.NewSingleAnswer(
                    new DomainTypes.SingleAnswer(
                        OptionId.NewOptionId(optionId))));

            if (answerEvent != null)
            {
                eventStore.Add(typedGameId, answerEvent.Value);

                await SendNewState(typedGameId);
            }
        }

        private async Task SendNewState(GameId gameId)
        {
            await Clients.Group(GameGroupName).SendAsync("newState", gameStateDenormalizer.GetState(gameId));
            await Clients.Group(ClientGroupName).SendAsync("newState", clientStateDenormalizer.GetState(gameId));
        }
    }
}
