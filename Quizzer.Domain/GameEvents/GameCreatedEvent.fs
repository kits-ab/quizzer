namespace Quizzer.Domain

type GameCreatedEvent = { 
        GameId : GameId
        Questions : seq<Question> }