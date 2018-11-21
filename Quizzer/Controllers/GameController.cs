using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.FSharp.Collections;
using Quizzer.Domain;

namespace Quizzer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        //[HttpPost("{gameId}/{questionId}/{userId}")]
        //public void AnswerSingleAnswerQuestion(
        //    Guid gameId,
        //    Guid questionId,
        //    Guid userId,
        //    [FromBody] Guid optionId)
        //{
        //    var options = new FSharpMap<OptionId, OptionData>(new[]
        //        {Tuple.Create(OptionId.NewOptionId(optionId), new OptionData("Oi"))}
        //        );
        //    var question = QuestionData.NewSingleAnswerQuestionData(new SingleAnswerQuestionData("Wut?", options));
        //    var questions = new FSharpMap<QuestionId, QuestionData>(new[]
        //        {Tuple.Create(QuestionId.NewQuestionId(questionId), question)});
        //    var answer = Answer.NewSingleAnswerQuestionAnswer(OptionId.NewOptionId(optionId));
        //    var @event = Game.answerQuestion(new Game.Game(Game.GameId.NewGameId(gameId), questions, QuestionId.NewQuestionId(questionId)), UserId.NewUserId(userId), answer);
        //}
    }
}
