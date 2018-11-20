namespace Quizzer.Domain

type AnswerEvent = { 
        QuestionId : QuestionId
        UserId : UserId
        Data : AnswerEventData }

module AnswerEvent =
    let create (userId, questionId, answer) = { UserId = userId; QuestionId = questionId; Data = AnswerEventData.create answer }