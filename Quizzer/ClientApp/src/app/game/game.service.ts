import { Injectable } from '@angular/core';
import * as signalR from "@aspnet/signalr";
import { ActiveQuestion } from './states/ActiveQuestion';
import { SingleAnswerAnsweredQuestion } from './states/SingleAnswerAnsweredQuestion';
import { MultipleAnswerAnsweredQuestion } from './states/MultipleAnswerAnsweredQuestion';
import { NotEnoughPlayers } from './states/NotEnoughPlayers';
import { GameId } from '../common/IdTypes';
import { ClientComponent } from '../client/client/client.component';

@Injectable()
export class GameService {
  private connection: signalR.HubConnection;
  private gameCreatedHandlers: ((newGameId: GameId) => void)[] = [];
  private gameStateObservers: ((newState: GameState) => void)[] = [];

  constructor() {
    this.connection = new signalR.HubConnectionBuilder()
      .withUrl("/hub")
      .build();

    this.connection.start().catch(err => document.write(err));

    this.connection.on("newGame", (newGameId: GameId) => {
      for (let i = 0; i < this.gameCreatedHandlers.length; i++) {
        this.gameCreatedHandlers[i](newGameId);
        ClientComponent.availableGameId = newGameId;
      }
    });

    this.connection.on("newState", (newState: GameState) => {
      for (let i = 0; i < this.gameStateObservers.length; i++) {
        this.gameStateObservers[i](newState);
      }
    });
  }

  create(handler: (newGameId: GameId) => void): void {
    this.gameCreatedHandlers.push(handler);
    this.connection.send("create");
  }

  onNewState(handler: (newState: GameState) => void): void {
    this.gameStateObservers.push(handler);
  }
}

export type GameState = NotEnoughPlayers | ActiveQuestion | SingleAnswerAnsweredQuestion | MultipleAnswerAnsweredQuestion
