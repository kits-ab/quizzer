import { Component, Input } from '@angular/core';
import { AnsweredQuestion } from '../answered-question';
import { Answer } from '../answer';
import { PlayerService, PlayerId } from '../player.service';
import { OptionId, Option } from '../option';

@Component({
  selector: 'app-single-answer-answered-question',
  templateUrl: './single-answer-answered-question.component.html',
  styleUrls: ['./single-answer-answered-question.component.css']
})
export class SingleAnswerAnsweredQuestionComponent {

  @Input()
  question: SingleAnswerAnsweredQuestion;

  constructor(readonly playerService: PlayerService) { }

  getPlayerNamesAnswering(optionId: OptionId): string {
    const playerIds = this.question.answers
      .filter(answer => answer.optionId === optionId && answer.playerId != this.question.targetPlayerId)
      .map(x => x.playerId);

    const playerNames = playerIds
      .map(playerId => this.playerService.getPlayer(playerId))
      .map(player => player.name);

    return playerNames.join(", ");
  }

  isTargetPlayerAnswer(optionId: OptionId): boolean {
    const optionIsTargetPlayersAnswer = this.question.answers
      .some(answer => answer.playerId === this.question.targetPlayerId && answer.optionId === optionId);

    return optionIsTargetPlayersAnswer;
  }
}

export class SingleAnswerQuestionAnswer extends Answer {
  constructor(readonly optionId: OptionId, readonly playerId: PlayerId) {
    super(playerId);
  }
}

export class SingleAnswerAnsweredQuestion extends AnsweredQuestion {
  constructor(
    readonly targetPlayerId: PlayerId,
    readonly text: string,
    readonly options: Option[],
    readonly answers: SingleAnswerQuestionAnswer[]) {
    super(targetPlayerId, text, answers);
  }
}
