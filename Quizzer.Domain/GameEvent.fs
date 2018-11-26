namespace Quizzer.Domain

type GameEvent =
| AddQuestionEvent of AddQuestionEvent
| PlayerJoinedEvent of PlayerJoinedEvent
| PlayerLeftEvent of PlayerLeftEvent
| AnswerEvent of AnswerEvent