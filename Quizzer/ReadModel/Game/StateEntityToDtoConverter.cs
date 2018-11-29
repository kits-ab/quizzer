using System.Linq;
using Quizzer.Services.Game;
using Quizzer.Services.Game.States;

namespace Quizzer.ReadModel.Game
{
    public class StateEntityToDtoConverter : StateVisitor<State>
    {
        public State Convert(Services.Game.State state)
        {
            return state.Accept(this);
        }

        public override State Visit(ActiveQuestion state)
        {
            return new States.ActiveQuestion(state.TargetPlayerName, state.Text);
        }

        public override State Visit(MultipleAnswerAnsweredQuestion state)
        {
            return new States.MultipleAnswerAnsweredQuestion(
                state.TargetPlayerName,
                state.TargetPlayerAnswerOptionIds,
                state.Text,
                state.Options.Select(option => new States.MultipleAnswerAnsweredQuestion.Option(option.Id, option.Text)),
                state.OtherPlayerAnswers.Select(answer => new States.MultipleAnswerAnsweredQuestion.Answer(answer.OptionIds, answer.PlayerId)));
        }

        public override State Visit(NotEnoughPlayers state)
        {
            return new States.NotEnoughPlayers(state.NumberOfMorePlayersRequired);
        }

        public override State Visit(SingleAnswerAnsweredQuestion state)
        {
            return new States.SingleAnswerAnsweredQuestion(
                state.TargetPlayerName,
                state.TargetPlayerAnswerOptionId,
                state.Text,
                state.Options.Select(option => new States.SingleAnswerAnsweredQuestion.Option(option.Id, option.Text)),
                state.OtherPlayerAnswers.Select(answer => new States.SingleAnswerAnsweredQuestion.Answer(answer.OptionId, answer.PlayerId)));
        }
    }
}
