import { NgModule } from '@angular/core';
import { CommonModule } from "@angular/common";

import { ClientComponent } from './client/client.component';
import { SingleAnswerQuestionComponent } from './single-answer-question/single-answer-question.component';
import { QuestionComponent } from './question/question.component';
import { ClientViewComponent } from './client-view/client-view.component';

@NgModule({
  declarations: [
    ClientComponent,
    SingleAnswerQuestionComponent,
    QuestionComponent,
    ClientViewComponent
  ],
  imports: [
    CommonModule
  ],
  exports: [
    ClientComponent
  ],
  providers: [
  ]
})
export class ClientModule { }
