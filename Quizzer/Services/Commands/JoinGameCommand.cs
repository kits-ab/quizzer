using System;

namespace Quizzer.Services.Commands
{
    public class JoinGameCommand
    {
        public Guid GameId { get; }
        public Guid PlayerId { get; }
        public string PlayerName { get; }

        public JoinGameCommand(Guid gameId, Guid playerId, string playerName)
        {
            GameId = gameId;
            PlayerId = playerId;
            PlayerName = playerName;
        }
    }
}
