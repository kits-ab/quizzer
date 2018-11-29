using System.Linq;
using Quizzer.Services.Client;
using Quizzer.Services.Client.States;

namespace Quizzer.ReadModel.Client
{
    public class StateEntityToDtoConverter : StateVisitor<State>
    {
        public State Convert(Services.Client.State state)
        {
            return state.Accept(this);
        }

        public override State Visit(NotEnoughPlayers state)
        {
            return new States.NotEnoughPlayers();
        }

        public override State Visit(SingleAnswerQuestion state)
        {
            return new States.SingleAnswerQuestion(state.Options.Select(option => new States.SingleAnswerQuestion.Option(option.Id, option.Text)));
        }
    }
}
