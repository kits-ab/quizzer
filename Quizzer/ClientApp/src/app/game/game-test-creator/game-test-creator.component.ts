import { Component } from '@angular/core';
import { GameService } from '../game.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-game-test-creator',
  templateUrl: './game-test-creator.component.html',
  styleUrls: ['./game-test-creator.component.css']
})
export class GameTestCreatorComponent {

  constructor(readonly gameService: GameService, readonly router: Router) { }

  create(): void {
    this.gameService.create((newGameId) => {
      this.router.navigate(["/gameTest", newGameId]);
    });
  }
}
