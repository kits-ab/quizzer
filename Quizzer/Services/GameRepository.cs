using Quizzer.Domain;

namespace Quizzer.Services
{
    public class GameRepository
    {
        private readonly EventStore eventStore;

        public GameRepository(EventStore eventStore)
        {
            this.eventStore = eventStore;
        }

        public DomainTypes.Game GetById(GameId gameId)
        {
            var gameBuilder = new GameBuilder(eventStore.GetEvents(gameId));
            return gameBuilder.Game;
        }
    }
}
