import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { GameId } from '../../common/IdTypes';

@Component({
  selector: 'app-game-test',
  templateUrl: './game-test.component.html',
  styleUrls: ['./game-test.component.css']
})
export class GameTestComponent implements OnInit {

  gameId: GameId;

  constructor(readonly activatedRoute: ActivatedRoute) { }

  ngOnInit() {
    this.activatedRoute.params.subscribe(params => {
      this.gameId = params["gameId"];
    });
  }
}
