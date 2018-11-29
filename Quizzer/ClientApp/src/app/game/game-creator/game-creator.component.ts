import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { GameService } from '../game.service';

@Component({
  selector: 'app-game-creator',
  templateUrl: './game-creator.component.html',
  styleUrls: ['./game-creator.component.css']
})
export class GameCreatorComponent {

  constructor(readonly gameService: GameService, readonly router: Router) { }

  create(): void {
    this.gameService.create((newGameId) => {
      this.router.navigate(["/game", newGameId]);
    });
  }
}
