namespace Quizzer.Domain

[<AutoOpen>]
module DomainTypes =

    type Option = { Text : string }

    type OptionCollection = IdObjectCollection<OptionId, Option>

    type SingleAnswer = {
        OptionId : OptionId }

    type MultipleAnswer = {
        OptionIds : seq<OptionId> }

    type Answer =
    | SingleAnswer of SingleAnswer
    | MultipleAnswer of MultipleAnswer

    type SingleAnswerQuestion = {
        Text : string
        Options : OptionCollection }

    type MultipleAnswerQuestion = {
        Text : string
        Options : OptionCollection }

    type Question =
    | SingleAnswerQuestion of SingleAnswerQuestion
    | MultipleAnswerQuestion of MultipleAnswerQuestion

    type QuestionCollection = IdObjectCollection<QuestionId, Question>

    type Game = {
        Questions : QuestionCollection
        CurrentQuestionId : QuestionId }