import { Answer } from './answer';
import { PlayerId } from './player.service';

export abstract class AnsweredQuestion {
  protected constructor(readonly targetPlayerId: PlayerId, readonly text: string, readonly answers: Answer[]) { }
}
