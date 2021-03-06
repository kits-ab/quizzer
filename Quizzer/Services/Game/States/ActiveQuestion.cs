﻿namespace Quizzer.Services.Game.States
{
    public class ActiveQuestion : State
    {
        public ActiveQuestion(string targetPlayerName, string text)
        {
            TargetPlayerName = targetPlayerName;
            Text = text;
        }

        public string TargetPlayerName { get; }
        public string Text { get; }

        public override T Accept<T>(StateVisitor<T> visitor)
        {
            return visitor.Visit(this);
        }
    }
}
