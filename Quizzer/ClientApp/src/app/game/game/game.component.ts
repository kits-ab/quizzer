import { Component, OnInit } from '@angular/core';
import { AnsweredQuestion } from '../answered-question';
import { SingleAnswerAnsweredQuestion, SingleAnswerQuestionAnswer } from '../single-answer-answered-question/single-answer-answered-question.component';
import { MultipleAnswerAnsweredQuestion, MultipleAnswerQuestionAnswer } from '../multiple-answer-answered-question/multiple-answer-answered-question.component';
import { PlayerService } from '../player.service';
import { Option } from '../option';

@Component({
  selector: 'app-game',
  templateUrl: './game.component.html',
  styleUrls: ['./game.component.css']
})
export class GameComponent implements OnInit {
    
  currentQuestion: Question;

  constructor(private playerService: PlayerService) {}

  ngOnInit(): void {
    this.currentQuestion = new ActiveQuestion(this.playerService.getPlayer("1337").name, "What is my favorite color?");
  }

  tempMock() {
    if (this.currentQuestion instanceof ActiveQuestion) {
      this.currentQuestion = new SingleAnswerAnsweredQuestion("1337",
        "Still same text?",
        [new Option("Blue", "2"), new Option("Green", "1")],
        [new SingleAnswerQuestionAnswer("1", "1337"), new SingleAnswerQuestionAnswer("2", "1338")]);
    }
    else if (this.currentQuestion instanceof SingleAnswerAnsweredQuestion) {
      this.currentQuestion = new MultipleAnswerAnsweredQuestion("1337",
        "Still same text?",
        [new Option("Blue", "2"), new Option("Green", "1"), new Option("Red", "0")],
        [new MultipleAnswerQuestionAnswer(["1", "2"], "1337"), new MultipleAnswerQuestionAnswer(["2", "0"], "1338")]);
    }
  }

  isActiveQuestion(): boolean {
    return this.currentQuestion instanceof ActiveQuestion;
  }

  isAnsweredQuestion(): boolean {
    return this.currentQuestion instanceof AnsweredQuestion;
  }
}

type Question = ActiveQuestion | AnsweredQuestion;

export class ActiveQuestion {
  constructor(readonly targetPlayerName: string, readonly text: string) {}
}