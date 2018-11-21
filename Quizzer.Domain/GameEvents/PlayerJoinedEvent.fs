namespace Quizzer.Domain

type PlayerJoinedEvent = { 
        GameId : GameId
        PlayerId : PlayerId
        PlayerName : string }