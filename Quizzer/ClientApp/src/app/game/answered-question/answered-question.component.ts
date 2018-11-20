import { Component, Input, OnChanges, SimpleChanges, SimpleChange } from '@angular/core';
import { SingleAnswerAnsweredQuestion } from '../single-answer-answered-question/single-answer-answered-question.component';
import { MultipleAnswerAnsweredQuestion } from '../multiple-answer-answered-question/multiple-answer-answered-question.component';
import { AnsweredQuestion } from '../answered-question';
import { PlayerService } from '../player.service';

@Component({
  selector: 'app-answered-question',
  templateUrl: './answered-question.component.html',
  styleUrls: ['./answered-question.component.css']
})
export class AnsweredQuestionComponent implements OnChanges {
    
  @Input()
  question: AnsweredQuestion;

  targetPlayerName: string;

  constructor(readonly playerService: PlayerService) { }

  ngOnChanges(changes: SimpleChanges): void {
    const targetPlayer = this.playerService.getPlayer(this.question.targetPlayerId);
    this.targetPlayerName = targetPlayer.name;
  }

  isSingleAnswer(): boolean {
    return this.question instanceof SingleAnswerAnsweredQuestion;
  }

  isMultipleAnswer(): boolean {
    return this.question instanceof MultipleAnswerAnsweredQuestion;
  }
}
