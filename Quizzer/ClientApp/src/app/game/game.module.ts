import { NgModule } from '@angular/core';
import { CommonModule } from "@angular/common";

import { QuestionComponent } from './question/question.component';
import { GameComponent } from './game/game.component';
import { AnsweredQuestionComponent } from './answered-question/answered-question.component';
import { SingleAnswerAnsweredQuestionComponent } from './single-answer-answered-question/single-answer-answered-question.component';
import { MultipleAnswerAnsweredQuestionComponent } from './multiple-answer-answered-question/multiple-answer-answered-question.component';
import { GameService } from './game.service';
import { GameCreatorComponent } from './game-creator/game-creator.component';
import { GameViewComponent } from './game-view/game-view.component';
import { GameTestCreatorComponent } from './game-test-creator/game-test-creator.component';

@NgModule({
  declarations: [
    QuestionComponent,
    GameComponent,
    AnsweredQuestionComponent,
    SingleAnswerAnsweredQuestionComponent,
    MultipleAnswerAnsweredQuestionComponent,
    GameCreatorComponent,
    GameViewComponent,
    GameTestCreatorComponent,
  ],
  imports: [
    CommonModule
  ],
  exports: [
    GameComponent
  ],
  providers: [
    GameService
  ]
})
export class GameModule { }
