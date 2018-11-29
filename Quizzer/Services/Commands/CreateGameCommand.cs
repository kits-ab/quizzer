using System;

namespace Quizzer.Services.Commands
{
    public class CreateGameCommand
    {
        public Guid GameId { get; }

        public CreateGameCommand(Guid gameId)
        {
            GameId = gameId;
        }
    }
}
