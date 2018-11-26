using System;

namespace Quizzer.Services.Game.States
{
    public class ActiveQuestion : State
    {
        public ActiveQuestion(Guid targetPlayerId, string text)
        {
            TargetPlayerId = targetPlayerId;
            Text = text;
        }

        public Guid TargetPlayerId { get; }
        public string Text { get; }
    }
}
