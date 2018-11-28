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
import { GameComponent } from './game/game/game.component';
import { ClientComponent } from './client/client/client.component';

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
      { path: '', component: GameTestComponent, pathMatch: 'full' },
      { path: 'game', component: GameComponent },
      { path: 'client', component: ClientComponent },
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
