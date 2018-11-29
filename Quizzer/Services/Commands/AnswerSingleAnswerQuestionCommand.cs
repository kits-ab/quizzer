using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quizzer.Services.Commands
{
    public class AnswerSingleAnswerQuestionCommand
    {
        public Guid GameId { get; }
        public Guid PlayerId { get; }
        public Guid OptionId { get; }

        public AnswerSingleAnswerQuestionCommand(Guid gameId, Guid playerId, Guid optionId)
        {
            GameId = gameId;
            PlayerId = playerId;
            OptionId = optionId;
        }
    }
}
