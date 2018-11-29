using Quizzer.Services.Game.States;

namespace Quizzer.Services.Game
{
    public abstract class StateVisitor<T>
    {
        public abstract T Visit(ActiveQuestion state);
        public abstract T Visit(MultipleAnswerAnsweredQuestion state);
        public abstract T Visit(NotEnoughPlayers state);
        public abstract T Visit(SingleAnswerAnsweredQuestion state);
    }
}