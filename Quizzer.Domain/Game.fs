namespace Quizzer.Domain

open System

module Game =
    let currentQuestion game = game.Questions.TryFind game.CurrentQuestionId

    let create =
        { GameId = GameId(Guid.NewGuid()) }

    let join (gameId, newPlayerName) =
        { GameId = gameId; PlayerId = PlayerId(Guid.NewGuid()); PlayerName = newPlayerName }

    let leave (gameId, playerId) =
        { GameId = gameId; PlayerId = playerId }

    let addQuestion (gameId, questionData) = {
        GameId = gameId
        QuestionId = QuestionId(Guid.NewGuid())
        QuestionData = questionData }

    let answerQuestion (game, userId, answer) =
        match currentQuestion game with
        | Some question when Question.isValidAnswer (question, answer) -> Some(AnswerEvent.create (game.Id, userId, game.CurrentQuestionId, answer))
        | _ -> None