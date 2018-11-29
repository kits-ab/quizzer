namespace Quizzer.Services.Client
{
    public abstract class State
    {
        public abstract T Accept<T>(StateVisitor<T> visitor);
    }
}
