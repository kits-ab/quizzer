namespace Quizzer.Domain

type AnswerEvent = { 
    GameId : GameId
    QuestionId : QuestionId
    PlayerId : PlayerId
    Data : AnswerEventData }

module AnswerEvent =
    let create (gameId, playerId, questionId, answer) = {
        GameId = gameId
        PlayerId = playerId
        QuestionId = questionId
        Data = AnswerEventData.create answer }