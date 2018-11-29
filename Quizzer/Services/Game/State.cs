namespace Quizzer.Services.Game
{
    public abstract class State
    {
        public abstract T Accept<T>(StateVisitor<T> visitor);
    }
}
