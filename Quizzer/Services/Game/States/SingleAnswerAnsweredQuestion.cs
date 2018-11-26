using System;
using System.Collections.Generic;

namespace Quizzer.Services.Game.States
{
    public class SingleAnswerAnsweredQuestion : State
    {
        public SingleAnswerAnsweredQuestion(Guid targetPlayerId, string text, IEnumerable<Option> options, IEnumerable<Answer> answers)
        {
            TargetPlayerId = targetPlayerId;
            Text = text;
            Options = options;
            Answers = answers;
        }

        public Guid TargetPlayerId { get; }
    
        public string Text { get; }
        public IEnumerable<Option> Options { get; }
        public IEnumerable<Answer> Answers { get; }

        public class Option
        {
            public Option(string text, Guid id)
            {
                Text = text;
                Id = id;
            }

            public string Text { get; }
            public Guid Id { get; }
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
