namespace Quizzer.Domain

[<AutoOpen>]
module DomainTypes =

    type Option = { Text : string }

    type SingleAnswer = {
        OptionId : OptionId }

    type MultipleAnswer = {
        OptionIds : seq<OptionId> }

    type Answer =
    | SingleAnswer of SingleAnswer
    | MultipleAnswer of MultipleAnswer

    type SingleAnswerQuestion = {
        Text : string
        Options : Map<OptionId, Option> }

    type MultipleAnswerQuestion = {
        Text : string
        Options : Map<OptionId, Option> }

    type Question =
    | SingleAnswerQuestion of SingleAnswerQuestion
    | MultipleAnswerQuestion of MultipleAnswerQuestion

    type Player = { Name : string }

    type Game = {
        Questions : seq<QuestionId * Question>
        CurrentQuestionId : Option<QuestionId>
        CurrentQuestionAnswers : Map<PlayerId, Answer>
        Players : Map<PlayerId, Player>
        TargetPlayerId : Option<PlayerId> }