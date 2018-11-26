namespace Quizzer.Domain

module GameBuilder =
    let private addQuestion (game, newQuestionId, newQuestion) = 
        match game with
        | Some existingGame -> {
            existingGame with
                Questions = existingGame.Questions.Add(newQuestionId, newQuestion) }
        | None -> {
            Questions = QuestionCollection(Seq.singleton (newQuestionId, newQuestion))
            CurrentQuestionId = newQuestionId
            Players = PlayerCollection(Seq.empty)}

    let private addPlayer (game, newPlayerId, newPlayerName) = {
        game with
            Players = game.Players.Add(newPlayerId, { Name = newPlayerName })
    }

    let private removePlayer (game, playerId) = {
        game with
            Players = game.Players.Remove(playerId)
    }

    let apply (game, event) =
        match game, event with
        | _, AddQuestionEvent addQuestionEvent -> addQuestion (game, addQuestionEvent.QuestionId, addQuestionEvent.Question)
        | None, _ -> failwith "Game must be initiated with add question event"
        | Some game, PlayerJoinedEvent playerJoinedEvent -> addPlayer (game, playerJoinedEvent.PlayerId, playerJoinedEvent.PlayerName)
        | Some game, PlayerLeftEvent playerLeftEvent -> removePlayer (game, playerLeftEvent.PlayerId)
        | Some game, AnswerEvent answerEvent -> game