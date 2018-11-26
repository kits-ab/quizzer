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
            var numberOfPlayers = game.Players.Count;
            if (numberOfPlayers < 2)
            {
                return new NotEnoughPlayers(2 - numberOfPlayers);
            }
            var question = Domain.Game.currentQuestion(game).Value;
            //return new ActiveQuestion(
            //    Guid.Empty,
            //    Domain.Game.currentQuestion(game).Value.Text
            //);
            if (question.IsSingleAnswerQuestion)
            {
                var singleQuestion = ((DomainTypes.Question.SingleAnswerQuestion) question).Item;
                return new SingleAnswerAnsweredQuestion(
                    Guid.Empty,
                    singleQuestion.Text,
                    singleQuestion.Options.Select(option => new SingleAnswerAnsweredQuestion.Option(option.Value.Text, option.Key.Item)),
                    new List<SingleAnswerAnsweredQuestion.Answer>()
                );
            }

            return null;
        }
    }
}