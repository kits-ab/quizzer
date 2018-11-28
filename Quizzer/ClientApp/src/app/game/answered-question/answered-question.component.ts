import { Component, Input, OnChanges, SimpleChanges, SimpleChange } from '@angular/core';
import { SingleAnswerAnsweredQuestion } from '../single-answer-answered-question/single-answer-answered-question.component';
import { MultipleAnswerAnsweredQuestion } from '../multiple-answer-answered-question/multiple-answer-answered-question.component';
import { AnsweredQuestion } from '../answered-question';

@Component({
  selector: 'app-answered-question',
  templateUrl: './answered-question.component.html',
  styleUrls: ['./answered-question.component.css']
})
export class AnsweredQuestionComponent implements OnChanges {
    
  @Input()
  question: AnsweredQuestion;

  targetPlayerName: string;

  ngOnChanges(changes: SimpleChanges): void {
    this.targetPlayerName = this.question.targetPlayerName;
  }

  isSingleAnswer(): boolean {
    return this.question instanceof SingleAnswerAnsweredQuestion;
  }

  isMultipleAnswer(): boolean {
    return this.question instanceof MultipleAnswerAnsweredQuestion;
  }
}
