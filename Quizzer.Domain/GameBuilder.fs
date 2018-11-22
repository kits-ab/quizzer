namespace Quizzer.Domain

open System

module GameBuilder =
    let private createQuestionCollection (questions : seq<Question>) = Map.ofSeq (Seq.map (fun question -> (QuestionId(Guid.NewGuid()), question)) questions)

    let private createGame questionCollection = {
        Questions = questionCollection
        CurrentQuestionId = Seq.head (IdObjectCollection.Ids questionCollection) }

    let build (event : GameCreatedEvent) = createGame (createQuestionCollection event.Questions)

    let apply (game, event) =
        match event with
        | PlayerJoinedEvent playerJoinedEvent -> game
        | PlayerLeftEvent playerLeftEvent -> game
        | AnswerEvent answerEvent -> game