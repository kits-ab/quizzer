namespace Quizzer.Domain

type SingleAnswerQuestionAnswerEventData = { OptionId : OptionId }

type MultipleAnswerQuestionAnswerEventData = { OptionIds : List<OptionId> }

type AnswerEventData =
    | SingleAnswerQuestionAnswerEventData of SingleAnswerQuestionAnswerEventData
    | MultipleAnswerQuestionAnswerEventData of MultipleAnswerQuestionAnswerEventData

module AnswerEventData =
    let create answer =
        match (answer) with
            | SingleAnswerQuestionAnswer optionId -> SingleAnswerQuestionAnswerEventData({ OptionId = optionId })
            | MultipleAnswerQuestionAnswer optionIds -> MultipleAnswerQuestionAnswerEventData({ OptionIds = optionIds })