import { Component, Input, Output, EventEmitter } from '@angular/core';
import { Option } from '../../common/option';
import { OptionId } from '../../common/IdTypes';

@Component({
  selector: 'app-single-answer-question',
  templateUrl: './single-answer-question.component.html',
  styleUrls: ['./single-answer-question.component.css']
})
export class SingleAnswerQuestionComponent {
  @Input() question: SingleAnswerQuestion;
  @Output() newAnswer = new EventEmitter<SingleAnswerQuestionAnswer>();

  currentAnswer: OptionId;

  answer(optionId: OptionId): void {
    this.currentAnswer = optionId;
    this.newAnswer.emit(new SingleAnswerQuestionAnswer(optionId));
  }

  isCurrentAnswer(optionId: OptionId): boolean {
    return optionId === this.currentAnswer;
  }
}

export class SingleAnswerQuestion {
  constructor(readonly options: Option[]) {}
}

export class SingleAnswerQuestionAnswer {
  constructor(readonly optionId: OptionId) {}
}
