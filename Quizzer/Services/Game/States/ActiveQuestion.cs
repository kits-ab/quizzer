using System;

namespace Quizzer.Services.Game.States
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
    }
}
