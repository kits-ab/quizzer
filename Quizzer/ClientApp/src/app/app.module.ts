import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { GameModule } from './game/game.module';
import { ClientModule } from './client/client.module';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './temp/nav-menu/nav-menu.component';
import { HomeComponent } from './temp/home/home.component';
import { CounterComponent } from './temp/counter/counter.component';
import { FetchDataComponent } from './temp/fetch-data/fetch-data.component';
import { GameTestComponent } from './temp/game-test/game-test.component';
import { GameCreatorComponent } from './game/game-creator/game-creator.component';
import { GameViewComponent } from './game/game-view/game-view.component';
import { ClientViewComponent } from './client/client-view/client-view.component';
import { GameTestCreatorComponent } from './game/game-test-creator/game-test-creator.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    GameTestComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    GameModule,
    ClientModule,
    RouterModule.forRoot([
      { path: '', component: GameTestCreatorComponent, pathMatch: 'full' },
      { path: 'gameTest/:gameId', component: GameTestComponent },
      { path: 'game/create', component: GameCreatorComponent },
      { path: 'game/:gameId', component: GameViewComponent },
      { path: 'client/:gameId', component: ClientViewComponent },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
    ])
  ],
  bootstrap: [
    AppComponent,
    //GameTestComponent,
    //GameComponent,
    //ClientComponent
  ]
})
export class AppModule { }
