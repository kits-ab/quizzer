namespace Quizzer.ReadModel
{
    public abstract class State
    {
        public string Type { get; }

        protected State()
        {
            Type = GetType().Name;
        }
    }
}
