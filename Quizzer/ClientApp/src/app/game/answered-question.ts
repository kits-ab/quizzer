import { Answer } from './answer';

export abstract class AnsweredQuestion {
  protected constructor(readonly targetPlayerName: string, readonly text: string, readonly otherPlayerAnswers: Answer[]) { }
}
