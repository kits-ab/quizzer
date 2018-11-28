import { Component, Input, Output, EventEmitter } from '@angular/core';
import { Question, Answer } from "../client/client.component";
import { SingleAnswerQuestion, SingleAnswerQuestionAnswer } from '../single-answer-question/single-answer-question.component';

@Component({
  selector: 'app-question',
  templateUrl: './question.component.html',
  styleUrls: ['./question.component.css']
})
export class QuestionComponent{
  @Input() question: Question;
  @Output() newAnswer = new EventEmitter<Answer>();

  isSingleAnswer(): boolean {
    return this.question instanceof SingleAnswerQuestion;
  }

  onSingleAnswer(answer: SingleAnswerQuestionAnswer): void {
    this.newAnswer.emit(answer);
  }
}
