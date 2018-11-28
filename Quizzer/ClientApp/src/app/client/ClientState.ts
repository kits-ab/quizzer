import { NotEnoughPlayers } from "./states/NotEnoughPlayers";
import { SingleAnswerQuestion } from "./states/SingleAnswerQuestion";

export type ClientState = NotEnoughPlayers | SingleAnswerQuestion;
