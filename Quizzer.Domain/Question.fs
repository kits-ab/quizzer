namespace Quizzer.Domain

open System

type QuestionId = QuestionId of Guid

type SingleAnswerQuestionData = {
    Question : string
    Options : OptionCollection }

type MultipleAnswerQuestionData = {
    Question : string
    Options : OptionCollection }

type QuestionData =
| SingleAnswerQuestionData of SingleAnswerQuestionData
| MultipleAnswerQuestionData of MultipleAnswerQuestionData

type QuestionCollection = IdObjectCollection<QuestionId, QuestionData>

module Question =
    let isValidAnswer (question, answer) =
        match question, answer with
        | SingleAnswerQuestionData data, SingleAnswerQuestionAnswer optionId -> List.contains optionId (IdObjectCollection.Ids data.Options)
        | SingleAnswerQuestionData _, _ -> false
        | MultipleAnswerQuestionData data, MultipleAnswerQuestionAnswer optionIds -> List.forall (fun x -> List.contains x (IdObjectCollection.Ids data.Options)) optionIds
        | MultipleAnswerQuestionData _, _ -> false