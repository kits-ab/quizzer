using System;
using System.Collections.Generic;

namespace Quizzer.Services.Game.States
{
    public class MultipleAnswerAnsweredQuestion : State
    {
        public MultipleAnswerAnsweredQuestion(Guid targetPlayerName, IEnumerable<Guid> targetPlayerAnswerOptionIds, string text, IEnumerable<Option> options, IEnumerable<Answer> otherPlayerAnswers)
        {
            TargetPlayerName = targetPlayerName;
            TargetPlayerAnswerOptionIds = targetPlayerAnswerOptionIds;
            Text = text;
            Options = options;
            OtherPlayerAnswers = otherPlayerAnswers;
        }

        public Guid TargetPlayerName { get; }
        public IEnumerable<Guid> TargetPlayerAnswerOptionIds { get; }

        public string Text { get; }
        public IEnumerable<Option> Options { get; }
        public IEnumerable<Answer> OtherPlayerAnswers { get;  }

        public class Option
        {
            public Option(Guid id, string text)
            {
                Id = id;
                Text = text;
            }

            public Guid Id { get; set; }
            public string Text { get; set; }
        }

        public class Answer
        {
            public Answer(IEnumerable<Guid> optionIds, Guid playerId)
            {
                OptionIds = optionIds;
                PlayerId = playerId;
            }

            public IEnumerable<Guid> OptionIds { get; }
            public Guid PlayerId { get; }
        }

        public override T Accept<T>(StateVisitor<T> visitor)
        {
            return visitor.Visit(this);
        }
    }
}
