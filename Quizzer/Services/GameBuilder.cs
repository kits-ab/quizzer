using System.Collections.Generic;
using Quizzer.Domain;

namespace Quizzer.Services
{
    public class GameBuilder
    {
        public DomainTypes.Game Game { get; private set; }

        public GameBuilder(IEnumerable<GameEvent> events)
        {
            Game = Domain.Game.create;
            foreach (var @event in events)
            {
                Handle(@event);
            }
        }

        private void Handle(GameEvent @event)
        {
            Game = Domain.GameBuilder.apply(Game, @event);
        }
    }
}