namespace Quizzer.Domain

open System

module Game =
    let currentQuestion (game : Game) = game.Questions.TryFind game.CurrentQuestionId

    let create questions = {
        GameId = GameId(Guid.Empty)//GameId(Guid.NewGuid())
        Questions = questions }

    let join (newPlayerName) = PlayerJoinedEvent { 
        PlayerId = PlayerId(Guid.NewGuid())
        PlayerName = newPlayerName }

    let leave (playerId) = PlayerLeftEvent {
        PlayerId = playerId }

    let private createAnswerEvent (playerId, questionId, answer) = AnswerEvent {
        PlayerId = playerId
        QuestionId = questionId
        Data = AnswerEventData.create answer }

    let answerQuestion (game, userId, answer) =
        match currentQuestion game with
        | Some question when Question.isValidAnswer (question, answer) -> Some(createAnswerEvent (userId, game.CurrentQuestionId, answer))
        | _ -> None