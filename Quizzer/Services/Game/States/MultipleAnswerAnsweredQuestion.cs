using System;
using System.Collections.Generic;

namespace Quizzer.Services.Game.States
{
    public class MultipleAnswerAnsweredQuestion : State
    {
        public Guid TargetPlayerName { get; set; }
        public IEnumerable<Guid> TargetPlayerAnswerOptionIds { get; }

        public string Text { get; set; }
        public IEnumerable<Option> Options { get; set; }
        public IEnumerable<Answer> OtherPlayerAnswers { get; set; }

        public class Option
        {
            public string Text { get; set; }
            public Guid Id { get; set; }
        }

        public class Answer
        {
            public IEnumerable<Guid> OptionIds { get; set; }
            public Guid PlayerId { get; set; }
        }
    }
}
