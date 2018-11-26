using System;
using System.Collections.Generic;
using Quizzer.Domain;

namespace Quizzer.Services
{
    public class EventStore
    {
        private readonly Dictionary<GameId, List<GameEvent>> events = new Dictionary<GameId, List<GameEvent>>();

        public void Add(GameId gameId, GameEvent @event)
        {
            if (!events.ContainsKey(gameId))
            {
                events.Add(gameId, new List<GameEvent>());
            }

            events[gameId].Add(@event);
        }

        public List<GameEvent> GetEvents(GameId gameId)
        {
            return events[gameId];
        }
    }
}