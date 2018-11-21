import { Injectable } from '@angular/core';
import * as signalR from "@aspnet/signalr";

@Injectable()
export class QuestionService {
  private connection: signalR.HubConnection;
  private observers: ((newQuestion) => void)[] = [];

  constructor() {
    this.connection = new signalR.HubConnectionBuilder()
      .withUrl("/hub")
      .build();

    this.connection.start().catch(err => document.write(err));

    this.connection.on("newQuestion", (message: string) => {
      for (let i = 0; i < this.observers.length; i++) {
        this.observers[i]({ tamp: message });
      }
    });
  }

  tempProvideAnswer() {
    this.connection.send("provideAnswer", "1337");
  }

  onNewQuestion(handler: (newQuestion) => void): void {
    this.observers.push(handler);
  }
}
