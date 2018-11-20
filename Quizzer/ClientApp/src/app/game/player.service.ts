import { Injectable } from '@angular/core';

@Injectable()
export class PlayerService {
  private players: { [id: string]: Player } = {
    "1337": new Player("1337", "Philip"),
    "1338": new Player("1338", "Emil"),
  };

  getPlayer(playerId: PlayerId): Player {
    return this.players[playerId];
  }
}

export type PlayerId = string;

export class Player {
  constructor(readonly id: PlayerId, readonly name: string) {}
}
