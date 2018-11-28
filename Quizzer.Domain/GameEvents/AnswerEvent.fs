namespace Quizzer.Domain

type AnswerEvent = { 
    PlayerId : PlayerId
    Data : AnswerEventData }