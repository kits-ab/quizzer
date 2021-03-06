﻿namespace Quizzer.Services.Game.States
{
    public class NotEnoughPlayers : State
    {
        public NotEnoughPlayers(int numberOfMorePlayersRequired)
        {
            NumberOfMorePlayersRequired = numberOfMorePlayersRequired;
        }

        public int NumberOfMorePlayersRequired { get; }

        public override T Accept<T>(StateVisitor<T> visitor)
        {
            return visitor.Visit(this);
        }
    }
}
