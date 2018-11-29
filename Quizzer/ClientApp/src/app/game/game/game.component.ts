import { Component, OnInit, Input } from '@angular/core';
import { AnsweredQuestion } from '../answered-question';
import { SingleAnswerAnsweredQuestion, SingleAnswerQuestionAnswer } from '../single-answer-answered-question/single-answer-answered-question.component';
import { MultipleAnswerAnsweredQuestion, MultipleAnswerQuestionAnswer } from '../multiple-answer-answered-question/multiple-answer-answered-question.component';
import { GameService } from '../game.service';
import { GameId } from '../../common/IdTypes';
import { Option } from '../../common/Option';

@Component({
  selector: 'app-game',
  templateUrl: './game.component.html',
  styleUrls: ['./game.component.css']
})
export class GameComponent implements OnInit {

  @Input() gameId: GameId;
  currentState: GameState;

  constructor(readonly gameService: GameService) { }

  ngOnInit(): void {
    this.gameService.onNewState((newState) => {
      switch (newState.type) {
        case "NotEnoughPlayers":
          this.currentState = new NotEnoughPlayers(newState.numberOfMorePlayersRequired);
          break;

        case "ActiveQuestion":
          this.currentState = new ActiveQuestion(
            newState.targetPlayerName,
            newState.text);
          break;

        case "SingleAnswerAnsweredQuestion":
          this.currentState = new SingleAnswerAnsweredQuestion(
            newState.targetPlayerName,
            newState.targetPlayerAnswerOptionId,
            newState.text,
            newState.options.map(option => new Option(option.id, option.text)),
            newState.otherPlayerAnswers.map(answer => new SingleAnswerQuestionAnswer(answer.optionId, answer.playerId))
          );
          break;

        case "MultipleAnswerAnsweredQuestion":
          this.currentState = new MultipleAnswerAnsweredQuestion(
            newState.targetPlayerName,
            newState.targetPlayerAnswerOptionIds,
            newState.text,
            newState.options.map(option => new Option(option.id, option.text)),
            newState.otherPlayerAnswers.map(answer => new MultipleAnswerQuestionAnswer(answer.optionIds, answer.playerId))
          );
          break;
      }
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
