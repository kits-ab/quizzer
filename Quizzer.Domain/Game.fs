namespace Quizzer.Domain

open System

module Game =
    type GameId = GameId of Guid

    type Game = {
        Id : GameId
        Questions : QuestionCollection
        CurrentQuestionId : QuestionId }

    let currentQuestion game = game.Questions.TryFind game.CurrentQuestionId

    let answerQuestion (game, userId, answer) =
        match currentQuestion game with
        | Some question when Question.isValidAnswer (question, answer) -> Some(AnswerEvent.create (userId, game.CurrentQuestionId, answer))
        | _ -> None