import { Injectable } from '@angular/core';
import { PlayerId } from "../common/IdTypes";

@Injectable()
export class PlayerService {
  private players: { [id: string]: Player } = {
    "00000000-0000-0000-0000-000000000000": new Player("00000000-0000-0000-0000-000000000000", "PhilipC"),
    "1337": new Player("1337", "Philip1337C"),
    "1338": new Player("1338", "EmilC"),
  };

  getPlayer(playerId: PlayerId): Player {
    return this.players[playerId];
  }
}

export class Player {
  constructor(readonly id: PlayerId, readonly name: string) {}
}
