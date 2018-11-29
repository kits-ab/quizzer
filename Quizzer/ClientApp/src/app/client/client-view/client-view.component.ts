import { Component, OnInit } from '@angular/core';
import { GameId } from '../../common/IdTypes';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-client-view',
  templateUrl: './client-view.component.html',
  styleUrls: ['./client-view.component.css']
})
export class ClientViewComponent implements OnInit {

  gameId: GameId;

  constructor(readonly activatedRoute: ActivatedRoute) { }

  ngOnInit() {
    this.activatedRoute.params.subscribe(params => {
      this.gameId = params["gameId"];
    });
  }
}
