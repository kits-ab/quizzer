using System;
using Quizzer.Domain;
using Quizzer.Services.Game;

namespace Quizzer.ReadModel.Game
{
    public class GameStateReadModel
    {
        private readonly GameStateDenormalizer gameStateDenormalizer;
        private readonly StateEntityToDtoConverter stateEntityToDtoConverter;

        public GameStateReadModel(GameStateDenormalizer gameStateDenormalizer, StateEntityToDtoConverter stateEntityToDtoConverter)
        {
            this.gameStateDenormalizer = gameStateDenormalizer;
            this.stateEntityToDtoConverter = stateEntityToDtoConverter;
        }

        public State GetState(Guid gameId)
        {
            return stateEntityToDtoConverter.Convert(gameStateDenormalizer.GetState(GameId.NewGameId(gameId)));
        }
    }
}
