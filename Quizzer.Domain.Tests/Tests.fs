module Tests

open NUnit.Framework
open Quizzer.Domain
open System

[<Test>]
let ``My test`` () =
    //let options = [| { Id = OptionId Guid.Empty; Data = { Text = "Doe!" } } |]
    //let singleQuestion = SingleAnswerQuestion(QuestionId Guid.Empty, { Question = "Mah doe?"; Options = options })
    //let singleAnswer = SingleAnswerQuestionAnswer(OptionId Guid.Empty)
    //let effect = Quizzer.Domain.Quizzer.answerQuestion(singleQuestion, singleAnswer)
    Assert.True(true)