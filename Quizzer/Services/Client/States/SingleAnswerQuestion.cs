﻿using System;
using System.Collections.Generic;

namespace Quizzer.Services.Client.States
{
    public class SingleAnswerQuestion : State
    {
        public SingleAnswerQuestion(IEnumerable<Option> options)
        {
            Options = options;
        }

        public IEnumerable<Option> Options { get; }

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

        public override T Accept<T>(StateVisitor<T> visitor)
        {
            return visitor.Visit(this);
        }
    }
}
