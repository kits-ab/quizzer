namespace Quizzer.Domain

module Question =
    let isValidAnswer (question, answer) =
        match question, answer with
        | SingleAnswerQuestion singleAnswerQuestion, SingleAnswer singleAnswer -> SingleAnswerQuestion.isValidAnswer (singleAnswerQuestion, singleAnswer)
        | SingleAnswerQuestion _, _ -> false
        | MultipleAnswerQuestion multipleAnswerQuestion, MultipleAnswer multipleAnswer -> MultipleAnswerQuestion.isValidAnswer (multipleAnswerQuestion, multipleAnswer)
        | MultipleAnswerQuestion _, _ -> false