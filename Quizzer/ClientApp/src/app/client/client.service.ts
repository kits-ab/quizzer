import { Injectable } from "@angular/core";
import * as signalR from "@aspnet/signalr";
import { GameId, PlayerId, OptionId } from "../common/IdTypes";
import { NotEnoughPlayers } from "./states/NotEnoughPlayers";

@Injectable()
export class ClientService {
  private connection: signalR.HubConnection;
  private clientStateObservers: ((newState: ClientState) => void)[] = [];
  private newPlayerObservers: ((playerId: PlayerId) => void)[] = [];

  provideSingleAnswer(gameId: GameId, playerId: PlayerId, optionId: OptionId): void {
    this.connection.send(
      "ProvideSingleAnswer",
      gameId,
      playerId,
      optionId);
  }

  join(gameId: GameId, playerName: string): void {
    this.connection = new signalR.HubConnectionBuilder()
      .withUrl("/hub")
      .build();

    this.connection.on("newState", (newState: ClientState) => {
      for (let i = 0; i < this.clientStateObservers.length; i++) {
        this.clientStateObservers[i](newState);
      }
    });

    this.connection.on("newPlayer", (playerId: PlayerId) => {
      for (let i = 0; i < this.newPlayerObservers.length; i++) {
        this.newPlayerObservers[i](playerId);
      }
    });

    this.connection.start().catch(err => document.write(err)).then(() => {
      this.connection.send("join", gameId, playerName);
    });
  }

  onNewState(handler: (newState: ClientState) => void): void {
    this.clientStateObservers.push(handler);
  }

  onNewPlayer(handler: (playerId: PlayerId) => void): void {
    this.newPlayerObservers.push(handler);
  }
}

export type ClientState = NotEnoughPlayers;
