import { Injectable } from '@angular/core';
import * as signalR from "@aspnet/signalr";
import { AnsweredQuestion } from './answered-question';
import { SingleAnswerAnsweredQuestion } from './single-answer-answered-question/single-answer-answered-question.component';
import { ActiveQuestion } from './game/game.component';

@Injectable()
export class QuestionService {
  private connection: signalR.HubConnection;
  private newQuestionObservers: ((newQuestion: ActiveQuestion) => void)[] = [];
  private questionAnsweredObservers: ((answeredQuestion: SingleAnswerAnsweredQuestion) => void)[] = [];

  constructor() {
    this.connection = new signalR.HubConnectionBuilder()
      .withUrl("/hub")
      .build();

    this.connection.start().catch(err => document.write(err));

    this.connection.on("newQuestion", (question: ActiveQuestion) => {
      for (let i = 0; i < this.newQuestionObservers.length; i++) {
        this.newQuestionObservers[i](question);
      }
    });

    this.connection.on("questionAnswered", (answeredQuestion: SingleAnswerAnsweredQuestion) => {
      for (let i = 0; i < this.newQuestionObservers.length; i++) {
        this.questionAnsweredObservers[i](answeredQuestion);
      }
    });
  }

  tempProvideAnswer() {
    this.connection.send("provideAnswer", "00000000-0000-0000-0000-000000000000");
  }

  tempJoin() {
    this.connection.send("join", "00000000-0000-0000-0000-000000000000", "PhilipC");
  }

  onNewQuestion(handler: (newQuestion: ActiveQuestion) => void): void {
    this.newQuestionObservers.push(handler);
  }

  onQuestionAnswered(handler: (answeredQuestion: SingleAnswerAnsweredQuestion) => void): void {
    this.questionAnsweredObservers.push(handler);
  }
}
