using System.Collections.Generic;
using Microsoft.FSharp.Core;
using Quizzer.Domain;

namespace Quizzer.Services
{
    public class GameBuilder
    {
        public DomainTypes.Game Game { get; private set; }

        public GameBuilder(IEnumerable<GameEvent> events)
        {
            foreach (var @event in events)
            {
                Handle(@event);
            }
        }

        public void Handle(GameEvent @event)
        {
            Game = Domain.GameBuilder.apply(Game ?? FSharpOption<DomainTypes.Game>.None, @event);
        }
    }
}