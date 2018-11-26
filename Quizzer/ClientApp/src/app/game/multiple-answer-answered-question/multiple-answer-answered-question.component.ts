import { Component, Input } from '@angular/core';
import { AnsweredQuestion } from '../answered-question';
import { Answer } from '../answer';
import { PlayerService } from '../player.service';
import { Option } from '../option';
import { OptionId, PlayerId } from "../../common/IdTypes";

@Component({
  selector: 'app-multiple-answer-answered-question',
  templateUrl: './multiple-answer-answered-question.component.html',
  styleUrls: ['./multiple-answer-answered-question.component.css']
})
export class MultipleAnswerAnsweredQuestionComponent {

  @Input()
  question: MultipleAnswerAnsweredQuestion;

  constructor(readonly playerService: PlayerService) { }

  getPlayerNamesAnswering(optionId: OptionId): string {
    const playerIds = this.question.answers
      .filter(answer => answer.optionIds.includes(optionId) && answer.playerId != this.question.targetPlayerId)
      .map(answer => answer.playerId);

    const playerNames = playerIds
      .map(playerId => this.playerService.getPlayer(playerId))
      .map(player => player.name);

    return playerNames.join(", ");
  }

  isTargetPlayerAnswer(optionId: OptionId): boolean {
    const optionIsTargetPlayersAnswer = this.question.answers
      .some(answer => answer.playerId === this.question.targetPlayerId && answer.optionIds.includes(optionId));

    return optionIsTargetPlayersAnswer;
  }
}

export class MultipleAnswerQuestionAnswer extends Answer {
  constructor(readonly optionIds: OptionId[], readonly playerId: PlayerId) {
    super(playerId);
  }
}

export class MultipleAnswerAnsweredQuestion extends AnsweredQuestion {
  constructor(
    readonly targetPlayerId: PlayerId,
    readonly text: string,
    readonly options: Option[],
    readonly answers: MultipleAnswerQuestionAnswer[]) {
    super(targetPlayerId, text, answers);
  }
}
