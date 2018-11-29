using Quizzer.Services.Client.States;

namespace Quizzer.Services.Client
{
    public abstract class StateVisitor<T>
    {
        public abstract T Visit(NotEnoughPlayers state);
        public abstract T Visit(SingleAnswerQuestion state);
    }
}