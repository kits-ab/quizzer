namespace Quizzer.Domain

module GameBuilder =
    let private addQuestion (game, newQuestionId, newQuestion) = 
        match game.CurrentQuestionId with 
        | None -> {
            game with
                Questions = Seq.append game.Questions (Seq.singleton (newQuestionId, newQuestion))
                CurrentQuestionId = Some newQuestionId }
        | _ -> {
            game with
                Questions = Seq.append game.Questions (Seq.singleton (newQuestionId, newQuestion)) }

    let private addPlayer (game, newPlayerId, newPlayerName) = 
        match game.TargetPlayerId with 
        | None -> {
                game with
                    Players = game.Players.Add(newPlayerId, { Name = newPlayerName })
                    TargetPlayerId = Some newPlayerId
            }
        | _ -> {
            game with
                Players = game.Players.Add(newPlayerId, { Name = newPlayerName })
        }

    let private removePlayer (game, playerId) = {
        game with
            Players = game.Players.Remove(playerId)
    }

    let private createAnswer eventData =
        match eventData with
        | SingleAnswerQuestionAnswerEventData data -> SingleAnswer { OptionId = data.OptionId }
        | MultipleAnswerQuestionAnswerEventData data -> MultipleAnswer { OptionIds = data.OptionIds }

    let private addAnswer (game, playerId, answer) = 
        match game.CurrentQuestionAnswers.Count with 
        | numberOfAnswers when not (game.CurrentQuestionAnswers.ContainsKey(playerId)) && numberOfAnswers = game.Players.Count - 1 -> {
                game with
                    CurrentQuestionAnswers = Map.empty
                    CurrentQuestionId = Game.nextQuestionId game
            }
        | _ -> {
            game with
                CurrentQuestionAnswers = game.CurrentQuestionAnswers.Add(playerId, answer)
        }

    let apply (game, event) =
        match event with
        | AddQuestionEvent addQuestionEvent -> addQuestion (game, addQuestionEvent.QuestionId, addQuestionEvent.Question)
        | PlayerJoinedEvent playerJoinedEvent -> addPlayer (game, playerJoinedEvent.PlayerId, playerJoinedEvent.PlayerName)
        | PlayerLeftEvent playerLeftEvent -> removePlayer (game, playerLeftEvent.PlayerId)
        | AnswerEvent answerEvent -> addAnswer (game, answerEvent.PlayerId, createAnswer answerEvent.Data)