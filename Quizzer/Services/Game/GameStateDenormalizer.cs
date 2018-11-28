using System;
using System.Collections.Generic;
using System.Linq;
using Quizzer.Domain;
using Quizzer.Services.Game.States;

namespace Quizzer.Services.Game
{
    public class GameStateDenormalizer
    {
        private readonly GameRepository gameRepository;

        public GameStateDenormalizer(GameRepository gameRepository)
        {
            this.gameRepository = gameRepository;
        }

        public object GetState(GameId gameId)
        {
            var game = gameRepository.GetById(gameId);
            var acceptingAnswersResult = Domain.Game.isAcceptingAnswers(game);
            if (acceptingAnswersResult.IsNotEnoughPlayers)
            {
                var notEnoughPlayers = ((Domain.Game.IsAcceptingAnswers.NotEnoughPlayers) acceptingAnswersResult).Item;
                return new NotEnoughPlayers(notEnoughPlayers.NumberOfMorePlayersNeeded);
            }
            var question = Domain.Game.currentQuestion(game).Value;
            if (question.IsSingleAnswerQuestion)
            {
                var singleQuestion = ((DomainTypes.Question.SingleAnswerQuestion) question).Item;

                return new ActiveQuestion(
                    Domain.Game.targetPlayer(game).Value.Name,
                    singleQuestion.Text
                );

                //return new SingleAnswerAnsweredQuestion(
                //    Guid.Empty,
                //    singleQuestion.Text,
                //    singleQuestion.Options.Select(option => new SingleAnswerAnsweredQuestion.Option(option.Value.Text, option.Key.Item)),
                //    new List<SingleAnswerAnsweredQuestion.Answer>()
                //);
            }

            return null;
        }
    }
}