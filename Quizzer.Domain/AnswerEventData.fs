namespace Quizzer.Domain

type SingleAnswerQuestionAnswerEventData = { OptionId : OptionId }

type MultipleAnswerQuestionAnswerEventData = { OptionIds : List<OptionId> }

type AnswerEventData =
    | SingleAnswerQuestionAnswerEventData of SingleAnswerQuestionAnswerEventData
    | MultipleAnswerQuestionAnswerEventData of MultipleAnswerQuestionAnswerEventData

module AnswerEventData =
    let create answer =
        match (answer) with
            | SingleAnswer singleAnswer -> SingleAnswerQuestionAnswerEventData({ OptionId = singleAnswer.OptionId })
            | MultipleAnswer multipleAnswer -> MultipleAnswerQuestionAnswerEventData({ OptionIds = multipleAnswer.OptionIds })