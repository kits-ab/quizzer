namespace Quizzer.Services.Client.States
{
    public class NotEnoughPlayers : State
    {
        public override T Accept<T>(StateVisitor<T> visitor)
        {
            return visitor.Visit(this);
        }
    }
}
