import { Answer } from './answer';
import { PlayerId } from '../common/IdTypes';

export abstract class AnsweredQuestion {
  protected constructor(readonly targetPlayerId: PlayerId, readonly text: string, readonly answers: Answer[]) { }
}
