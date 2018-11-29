using System.Linq;
using Quizzer.Domain;
using Quizzer.Services.Client.States;
using SingleAnswerQuestion = Quizzer.Services.Client.States.SingleAnswerQuestion;

namespace Quizzer.Services.Client
{
    public class ClientStateDenormalizer
    {
        private readonly GameRepository gameRepository;

        public ClientStateDenormalizer(GameRepository gameRepository)
        {
            this.gameRepository = gameRepository;
        }

        public State GetState(GameId gameId)
        {
            var game = gameRepository.GetById(gameId);
            var acceptsAnswersResult = Domain.Game.isAcceptingAnswers(game);
            if (acceptsAnswersResult.IsNotEnoughPlayers)
            {
                return new NotEnoughPlayers();
            }

            var question = Domain.Game.currentQuestion(game).Value;
            if (question.IsSingleAnswerQuestion)
            {
                var singleQuestion = ((DomainTypes.Question.SingleAnswerQuestion) question).Item;

                return new SingleAnswerQuestion(singleQuestion.Options.Select(pair => new SingleAnswerQuestion.Option(pair.Item1.Item, pair.Item2.Text)));
            }

            return null;
        }
    }
}