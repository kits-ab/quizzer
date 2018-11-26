import { NgModule } from '@angular/core';
import { CommonModule } from "@angular/common";

import { QuestionComponent } from './question/question.component';
import { GameComponent } from './game/game.component';
import { AnsweredQuestionComponent } from './answered-question/answered-question.component';
import { PlayerService } from './player.service';
import { SingleAnswerAnsweredQuestionComponent } from './single-answer-answered-question/single-answer-answered-question.component';
import { MultipleAnswerAnsweredQuestionComponent } from './multiple-answer-answered-question/multiple-answer-answered-question.component';
import { GameService } from './game.service';

@NgModule({
  declarations: [
    QuestionComponent,
    GameComponent,
    AnsweredQuestionComponent,
    SingleAnswerAnsweredQuestionComponent,
    MultipleAnswerAnsweredQuestionComponent
  ],
  imports: [
    CommonModule
  ],
  exports: [
    GameComponent
  ],
  providers: [
    PlayerService,
    GameService
  ]
})
export class GameModule { }
