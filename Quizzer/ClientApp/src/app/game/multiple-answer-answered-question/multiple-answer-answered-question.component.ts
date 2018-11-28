import { Component, Input } from '@angular/core';
import { AnsweredQuestion } from '../answered-question';
import { Answer } from '../answer';
import { OptionId } from "../../common/IdTypes";
import { Option } from '../../common/option';

@Component({
  selector: 'app-multiple-answer-answered-question',
  templateUrl: './multiple-answer-answered-question.component.html',
  styleUrls: ['./multiple-answer-answered-question.component.css']
})
export class MultipleAnswerAnsweredQuestionComponent {

  @Input()
  question: MultipleAnswerAnsweredQuestion;

  getPlayerNamesAnswering(optionId: OptionId): string {
    const playerNames = this.question.otherPlayerAnswers
      .filter(answer => answer.optionIds.includes(optionId))
      .map(answer => answer.playerName);

    return playerNames.join(", ");
  }

  isTargetPlayerAnswer(optionId: OptionId): boolean {
    return this.question.targetPlayerAnswer.includes(optionId);
  }
}

export class MultipleAnswerQuestionAnswer extends Answer {
  constructor(readonly optionIds: OptionId[], readonly playerName: string) {
    super(playerName);
  }
}

export class MultipleAnswerAnsweredQuestion extends AnsweredQuestion {
  constructor(
    readonly targetPlayerName: string,
    readonly targetPlayerAnswer: OptionId[],
    readonly text: string,
    readonly options: Option[],
    readonly otherPlayerAnswers: MultipleAnswerQuestionAnswer[]) {
    super(targetPlayerName, text, otherPlayerAnswers);
  }
}
