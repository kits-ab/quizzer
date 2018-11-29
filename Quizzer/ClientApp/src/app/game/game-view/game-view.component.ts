import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { GameId } from '../../common/IdTypes';

@Component({
  selector: 'app-game-view',
  templateUrl: './game-view.component.html',
  styleUrls: ['./game-view.component.css']
})
export class GameViewComponent implements OnInit {

  gameId: GameId;

  constructor(readonly activatedRoute: ActivatedRoute) { }

  ngOnInit() {
    this.activatedRoute.params.subscribe(params => {
      this.gameId = params["gameId"];
    });
  }
}
