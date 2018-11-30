using Quizzer.Domain;
using Quizzer.Services.Commands;

namespace Quizzer.Services
{
    public class CommandHandler
    {
        private readonly EventStore eventStore;
        private readonly GameRepository gameRepository;

        public CommandHandler(EventStore eventStore, GameRepository gameRepository)
        {
            this.eventStore = eventStore;
            this.gameRepository = gameRepository;
        }

        public void Handle(CreateGameCommand command)
        {
            var gameId = GameId.NewGameId(command.GameId);
            eventStore.Add(gameId, Domain.Game.addQuestion(SingleAnswerQuestion.create("What is my favorite color?", new[] { "Red", "Green", "Blue" })));
            eventStore.Add(gameId, Domain.Game.addQuestion(SingleAnswerQuestion.create("Which is my favorite animal?", new[] { "Dog", "Cat", "Alligator", "Snail" })));
            eventStore.Add(gameId, Domain.Game.addQuestion(SingleAnswerQuestion.create("Do I believe the cake is a lie?", new[] { "Yes", "No" })));
            eventStore.Add(gameId, Domain.Game.addQuestion(MultipleAnswerQuestion.create("What are my favorite colors?", new[] { "Red", "Green", "Blue", "Yellow" })));
        }

        public void Handle(JoinGameCommand command)
        {
            var gameId = GameId.NewGameId(command.GameId);
            var playerId = PlayerId.NewPlayerId(command.PlayerId);
            var joinEvent = Domain.Game.join(playerId, command.PlayerName);
            eventStore.Add(gameId, joinEvent);
        }

        public void Handle(AnswerSingleAnswerQuestionCommand command)
        {
            var gameId = GameId.NewGameId(command.GameId);
            var playerId = PlayerId.NewPlayerId(command.PlayerId);
            var optionId = OptionId.NewOptionId(command.OptionId);

            var game = gameRepository.GetById(gameId);
            var answerEvent = Domain.Game.answerQuestion(
                game,
                playerId,
                DomainTypes.Answer.NewSingleAnswer(
                    new DomainTypes.SingleAnswer(
                        optionId)));

            if (answerEvent != null)
            {
                eventStore.Add(gameId, answerEvent.Value);
            }
        }
    }
}
