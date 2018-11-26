import { Component, OnInit } from '@angular/core';
import { AnsweredQuestion } from '../answered-question';
import { SingleAnswerAnsweredQuestion, SingleAnswerQuestionAnswer } from '../single-answer-answered-question/single-answer-answered-question.component';
import { MultipleAnswerAnsweredQuestion, MultipleAnswerQuestionAnswer } from '../multiple-answer-answered-question/multiple-answer-answered-question.component';
import { PlayerService } from '../player.service';
import { Option } from '../option';
import { GameService } from '../game.service';
import { GameId } from 'app/common/IdTypes';


@Component({
  selector: 'app-game',
  templateUrl: './game.component.html',
  styleUrls: ['./game.component.css']
})
export class GameComponent implements OnInit {

  gameId: GameId;
  currentState: GameState;

  constructor(readonly playerService: PlayerService, readonly gameService: GameService) { }

  ngOnInit(): void {
    this.currentState = new ActiveQuestion(this.playerService.getPlayer("1337").name, "What is my favorite color?C");

    this.gameService.onNewState((newState) => {
      if (newState.type === "NotEnoughPlayers") {
        this.currentState = new NotEnoughPlayers(newState.numberOfMorePlayersRequired);
      }
      else if (newState.type === "ActiveQuestion") {
        this.currentState = new ActiveQuestion(
          this.playerService.getPlayer(newState.targetPlayerId).name,
          newState.text);
      }
      else if (newState.type === "SingleAnswerAnsweredQuestion") {
        this.currentState = new SingleAnswerAnsweredQuestion(
          newState.targetPlayerId,
          newState.text,
          newState.options.map(option => new Option(option.text, option.id)),
          newState.answers.map(answer => new SingleAnswerQuestionAnswer(answer.optionId, answer.playerId))
        );
      }
      else if (newState.type === "MultipleAnswerAnsweredQuestion") {
        this.currentState = new MultipleAnswerAnsweredQuestion(
          newState.targetPlayerId,
          newState.text,
          newState.options.map(option => new Option(option.text, option.id)),
          newState.answers.map(answer => new MultipleAnswerQuestionAnswer(answer.optionIds, answer.playerId))
        );
      }
    });
  }

  tempMock() {
    if (this.currentState instanceof ActiveQuestion) {
      this.currentState = new SingleAnswerAnsweredQuestion("1337",
        "Still same text?C",
        [new Option("Blue", "2"), new Option("Green", "1")],
        [new SingleAnswerQuestionAnswer("1", "1337"), new SingleAnswerQuestionAnswer("2", "1338")]);
    }
    else if (this.currentState instanceof SingleAnswerAnsweredQuestion) {
      this.currentState = new MultipleAnswerAnsweredQuestion("1337",
        "Still same text?C",
        [new Option("Blue", "2"), new Option("Green", "1"), new Option("Red", "0")],
        [new MultipleAnswerQuestionAnswer(["1", "2"], "1337"), new MultipleAnswerQuestionAnswer(["2", "0"], "1338")]);
    }
  }

  hasGameId(): boolean {
    return this.gameId != null;
  }

  create(): void {
    this.gameService.create((newGameId) => {
      this.gameId = newGameId;
    });
  }

  isNotEnoughPlayers(): boolean {
    return this.currentState instanceof NotEnoughPlayers;
  }

  isActiveQuestion(): boolean {
    return this.currentState instanceof ActiveQuestion;
  }

  isAnsweredQuestion(): boolean {
    return this.currentState instanceof AnsweredQuestion;
  }
}

type GameState = NotEnoughPlayers | ActiveQuestion | AnsweredQuestion;

export class ActiveQuestion {
  constructor(readonly targetPlayerName: string, readonly text: string) {}
}

class NotEnoughPlayers {
  constructor(readonly numberOfMorePlayersRequired: number) {}
}
