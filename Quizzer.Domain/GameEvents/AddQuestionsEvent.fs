namespace Quizzer.Domain

type AddQuestionEvent = { 
    QuestionId : QuestionId
    Question : Question }