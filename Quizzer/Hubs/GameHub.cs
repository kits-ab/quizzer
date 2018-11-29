using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Quizzer.ReadModel.Client;
using Quizzer.ReadModel.Game;
using Quizzer.Services;
using Quizzer.Services.Commands;

namespace Quizzer.Hubs
{
    public class GameHub : Hub
    {
        private const string GameGroupName = "game";
        private const string ClientGroupName = "client";

        private readonly CommandHandler commandHandler;
        private readonly ClientStateReadModel clientStateReadModel;
        private readonly GameStateReadModel gameStateReadModel;

        public GameHub(CommandHandler commandHandler, ClientStateReadModel clientStateReadModel, GameStateReadModel gameStateReadModel)
        {
            this.commandHandler = commandHandler;
            this.clientStateReadModel = clientStateReadModel;
            this.gameStateReadModel = gameStateReadModel;
        }

        public async Task Create()
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, GameGroupName);

            var newGameId = Guid.NewGuid();
            commandHandler.Handle(new CreateGameCommand(newGameId));
            
            await Clients.All.SendAsync("newGame", newGameId);
            await SendNewState(newGameId);
        }

        public async Task Join(Guid gameId, string playerName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, ClientGroupName);

            var newPlayerId = Guid.NewGuid();
            commandHandler.Handle(new JoinGameCommand(gameId, newPlayerId, playerName));

            await Clients.Caller.SendAsync("newPlayer", newPlayerId);
            await SendNewState(gameId);
        }

        public async Task ProvideSingleAnswer(Guid gameId, Guid playerId, Guid optionId)
        {
            commandHandler.Handle(new AnswerSingleAnswerQuestionCommand(gameId, playerId, optionId));

            await SendNewState(gameId);
        }

        private async Task SendNewState(Guid gameId)
        {
            await Clients.Group(GameGroupName).SendAsync("newState", gameStateReadModel.GetState(gameId));
            await Clients.Group(ClientGroupName).SendAsync("newState", clientStateReadModel.GetState(gameId));
        }
    }
}
