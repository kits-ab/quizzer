namespace Quizzer.Domain

open System

module Game =
    let create = {
        Questions = List.empty
        CurrentQuestionId = None
        CurrentQuestionAnswers = Map.empty
        Players = Map.empty
        TargetPlayerId = None }

    let currentQuestion game = 
        match (Seq.tryFind (fun question -> Some (fst question) = game.CurrentQuestionId) game.Questions) with
        | Some question -> Some (snd question)
        | None -> None

    let nextQuestionId game = 
        match (Seq.tryItem 0 (Seq.skip 1 (Seq.skipWhile (fun (questionId, _) -> not (Some questionId = game.CurrentQuestionId)) game.Questions))) with
        | Some (questionId, _) -> Some questionId
        | None -> None

    let targetPlayer game =
        match game.TargetPlayerId with
        | Some targetPlayerId -> game.Players.TryFind targetPlayerId
        | None -> None

    let addQuestion question = AddQuestionEvent {
        QuestionId = QuestionId(Guid.NewGuid())
        Question = question }

    let join (newPlayerId, newPlayerName) = PlayerJoinedEvent { 
        PlayerId = newPlayerId
        PlayerName = newPlayerName }

    let leave (playerId) = PlayerLeftEvent {
        PlayerId = playerId }

    let private createAnswerEvent (playerId, answer) = AnswerEvent {
        PlayerId = playerId
        Data = AnswerEventData.create answer }

    type NotEnoughPlayers = { NumberOfMorePlayersNeeded: int }

    type IsAcceptingAnswers =
    | NotEnoughPlayers of NotEnoughPlayers
    | Yes

    let isAcceptingAnswers game =
        match game.Players.Count with
        | players when players < 2 -> NotEnoughPlayers { NumberOfMorePlayersNeeded = 2 - players }
        | _ -> Yes

    let answerQuestion (game, userId, answer) =
        match currentQuestion game with
        | Some question when Question.isValidAnswer (question, answer) -> Some(createAnswerEvent (userId, answer))
        | _ -> None