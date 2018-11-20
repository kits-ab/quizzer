namespace Quizzer.Domain

type Answer =
    | SingleAnswerQuestionAnswer of optionId : OptionId
    | MultipleAnswerQuestionAnswer of optionIds : List<OptionId>