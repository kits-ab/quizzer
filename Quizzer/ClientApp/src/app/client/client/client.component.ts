import { Component, OnInit } from '@angular/core';
import { GameId, PlayerId } from 'app/common/IdTypes';
import { ClientService } from '../client.service';

@Component({
  selector: 'app-client',
  templateUrl: './client.component.html',
  styleUrls: ['./client.component.css']
})
export class ClientComponent implements OnInit {

  static availableGameId: GameId;

  playerId: PlayerId;
  state: ClientState = new JoinGame();

  constructor(readonly clientService: ClientService) { }

  ngOnInit() {
    this.clientService.onNewState((newState) => {
      if (newState.type === "NotEnoughPlayers") {
        this.state = new NotEnoughPlayers();
      }
    });

    this.clientService.onNewPlayer((playerId) => {
      this.playerId = playerId;
    });
  }

  joinLatestGame(): void {
    if (this.state instanceof JoinGame) {
      this.clientService.join(this.state.availableGameId, "Philip");
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
}

type ClientState = JoinGame | NotEnoughPlayers;

class JoinGame {
  constructor() { }

  get availableGameId(): GameId {
    return ClientComponent.availableGameId;
  }
}


class NotEnoughPlayers {
  constructor() {}
}
