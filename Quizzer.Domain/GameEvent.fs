namespace Quizzer.Domain

type GameEvent =
| PlayerJoinedEvent of PlayerJoinedEvent
| PlayerLeftEvent of PlayerLeftEvent
| AnswerEvent of AnswerEvent