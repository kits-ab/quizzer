using System;
using System.Collections.Generic;

namespace Quizzer.Services.Game.States
{
    public class SingleAnswerAnsweredQuestion : State
    {
        public SingleAnswerAnsweredQuestion(string targetPlayerName, Guid targetPlayerAnswerOptionId, string text, IEnumerable<Option> options, IEnumerable<Answer> otherPlayerAnswers)
        {
            TargetPlayerName = targetPlayerName;
            TargetPlayerAnswerOptionId = targetPlayerAnswerOptionId;
            Text = text;
            Options = options;
            OtherPlayerAnswers = otherPlayerAnswers;
        }

        public string TargetPlayerName { get; }
        public Guid TargetPlayerAnswerOptionId { get; }
    
        public string Text { get; }
        public IEnumerable<Option> Options { get; }
        public IEnumerable<Answer> OtherPlayerAnswers { get; }

        public class Option
        {
            public Option(Guid id, string text)
            {
                Id = id;
                Text = text;
            }

            public Guid Id { get; }
            public string Text { get; }
        }

        public class Answer
        {
            public Answer(Guid optionId, Guid playerId)
            {
                OptionId = optionId;
                PlayerId = playerId;
            }

            public Guid OptionId { get; }
            public Guid PlayerId { get; }
        }
    }
}
