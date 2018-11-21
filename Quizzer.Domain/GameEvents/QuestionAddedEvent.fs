namespace Quizzer.Domain

type QuestionAddedEvent = { 
        GameId : GameId
        QuestionId : QuestionId
        QuestionData : Question }

type QuestionAddedEvent2 = 
    | SingleAnswerQuestionAddedEvent of QuestionAddedEvent
    | MultipleAnswerQuestionAddedEvent of QuestionAddedEvent