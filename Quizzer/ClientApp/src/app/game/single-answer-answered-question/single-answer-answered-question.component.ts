import { Component, Input } from '@angular/core';
import { AnsweredQuestion } from '../answered-question';
import { Answer } from '../answer';
import { Option } from '../../common/Option';
import { OptionId, PlayerId } from '../../common/IdTypes';

@Component({
  selector: 'app-single-answer-answered-question',
  templateUrl: './single-answer-answered-question.component.html',
  styleUrls: ['./single-answer-answered-question.component.css']
})
export class SingleAnswerAnsweredQuestionComponent {

  @Input()
  question: SingleAnswerAnsweredQuestion;

  constructor() { }

  getPlayerNamesAnswering(optionId: OptionId): string {
    const playerNames = this.question.otherPlayerAnswers
      .filter(answer => answer.optionId === optionId)
      .map(x => x.playerName);

    return playerNames.join(", ");
  }

  isTargetPlayerAnswer(optionId: OptionId): boolean {
    const optionIsTargetPlayersAnswer = optionId === this.question.targetPlayerAnswer;

    return optionIsTargetPlayersAnswer;
  }
}

export class SingleAnswerQuestionAnswer extends Answer {
  constructor(readonly optionId: OptionId, readonly playerName: string) {
    super(playerName);
  }
}

export class SingleAnswerAnsweredQuestion extends AnsweredQuestion {
  constructor(
    readonly targetPlayerName: string,
    readonly targetPlayerAnswer: OptionId,
    readonly text: string,
    readonly options: Option[],
    readonly otherPlayerAnswers: SingleAnswerQuestionAnswer[]) {
    super(targetPlayerName, text, otherPlayerAnswers);
  }
}
