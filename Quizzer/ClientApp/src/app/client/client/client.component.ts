import { Component, Input, OnInit } from '@angular/core';
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
export class ClientComponent implements OnInit {

  private connection: HubConnection;

  @Input() gameId: GameId;
  playerId: PlayerId;
  state: ClientState;

  ngOnInit(): void {
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

    //var gameIdToJoin = this.gameId;
    this.connection.start().catch(err => document.write(err)).then(() => {
      this.connection.send("join", this.gameId, "Philip").then(() => {
        this.gameId = this.gameId;
      });
    });
  }

  onAnswer(answer: Answer): void {
    if (answer instanceof SingleAnswerQuestionAnswer) {
      this.connection.send(
        "ProvideSingleAnswer",
        this.gameId,
        this.playerId,
        answer.optionId);
    }
  }

  hasPlayerId(): boolean {
    return this.playerId != null;
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

type ClientState = NotEnoughPlayers | Question;

class NotEnoughPlayers {
  constructor() {}
}
