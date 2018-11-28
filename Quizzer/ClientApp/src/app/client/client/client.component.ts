import { Component } from '@angular/core';
import { HubConnection, HubConnectionBuilder } from "@aspnet/signalr";
import { GameId, PlayerId, OptionId } from "../../common/IdTypes";
import { ClientState as ClientStateContract } from "../ClientState";
import { SingleAnswerQuestion, SingleAnswerQuestionAnswer } from '../single-answer-question/single-answer-question.component';
import { Option } from '../../common/Option';

@Component({
  selector: 'app-client',
  templateUrl: './client.component.html',
  styleUrls: ['./client.component.css']
})
export class ClientComponent {

  static availableGameId: GameId;

  private connection: HubConnection;

  gameId: GameId;
  playerId: PlayerId;
  state: ClientState = new JoinGame();

  onAnswer(answer: Answer): void {
    if (answer instanceof SingleAnswerQuestionAnswer) {
      this.connection.send(
        "ProvideSingleAnswer",
        this.gameId,
        this.playerId,
        answer.optionId);
    }
  }

  provideSingleAnswer(gameId: GameId, playerId: PlayerId, optionId: OptionId): void {
    
  }

  joinLatestGame(): void {
    if (this.state instanceof JoinGame) {
      this.connection = new HubConnectionBuilder()
        .withUrl("/hub")
        .build();

      this.connection.on("newState", (newState: ClientStateContract) => {
        switch (newState.type) {
          case "NotEnoughPlayers":
            this.state = new NotEnoughPlayers();
            break;

          case "SingleAnswerQuestion":
            this.state = new SingleAnswerQuestion(newState.options.map(option => new Option(option.id, option.text)))
            break;
        }
      });

      this.connection.on("newPlayer", (playerId: PlayerId) => {
        this.playerId = playerId;
      });

      var gameIdToJoin = this.state.availableGameId;
      this.connection.start().catch(err => document.write(err)).then(() => {
        this.connection.send("join", gameIdToJoin, "Philip").then(() => {
          this.gameId = gameIdToJoin;
        });
      });
    }
  }

  hasPlayerId(): boolean {
    return this.playerId != null;
  }

  isJoinGame(): boolean {
    return this.state instanceof JoinGame;
  }

  isNotEnoughPlayers(): boolean {
    return this.state instanceof NotEnoughPlayers;
  }

  isQuestion(): boolean {
    return this.state instanceof SingleAnswerQuestion;
  }
}

export type Question = SingleAnswerQuestion;

export type Answer = SingleAnswerQuestionAnswer;

type ClientState = JoinGame | NotEnoughPlayers | Question;

class JoinGame {
  constructor() { }

  get availableGameId(): GameId {
    return ClientComponent.availableGameId;
  }
}

class NotEnoughPlayers {
  constructor() {}
}
