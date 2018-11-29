namespace Quizzer.ReadModel.Game.States
{
    public class NotEnoughPlayers : State
    {
        public NotEnoughPlayers(int numberOfMorePlayersRequired)
        {
            NumberOfMorePlayersRequired = numberOfMorePlayersRequired;
        }

        public int NumberOfMorePlayersRequired { get; }
    }
}
