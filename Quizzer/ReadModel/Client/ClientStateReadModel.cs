using System;
using Quizzer.Domain;
using Quizzer.Services.Client;

namespace Quizzer.ReadModel.Client
{
    public class ClientStateReadModel
    {
        private readonly ClientStateDenormalizer clientStateDenormalizer;
        private readonly StateEntityToDtoConverter stateEntityToDtoConverter;

        public ClientStateReadModel(ClientStateDenormalizer clientStateDenormalizer, StateEntityToDtoConverter stateEntityToDtoConverter)
        {
            this.clientStateDenormalizer = clientStateDenormalizer;
            this.stateEntityToDtoConverter = stateEntityToDtoConverter;
        }

        public State GetState(Guid gameId)
        {
            return stateEntityToDtoConverter.Convert(clientStateDenormalizer.GetState(GameId.NewGameId(gameId)));
        }
    }
}
