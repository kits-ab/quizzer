using Quizzer.Domain;
using Quizzer.Services.Client.States;

namespace Quizzer.Services.Client
{
    public class ClientStateDenormalizer
    {
        private readonly GameRepository gameRepository;

        public ClientStateDenormalizer(GameRepository gameRepository)
        {
            this.gameRepository = gameRepository;
        }

        public object GetState(GameId gameId)
        {
            var game = gameRepository.GetById(gameId);
            var numberOfPlayers = game.Players.Count;
            if (numberOfPlayers < 2)
            {
                return new NotEnoughPlayers();
            }

            return null;
        }
    }
}