namespace Quizzer.Domain

type AnswerEvent = { 
    QuestionId : QuestionId
    PlayerId : PlayerId
    Data : AnswerEventData }