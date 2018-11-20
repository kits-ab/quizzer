import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { GameModule } from './game/game.module';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './temp/nav-menu/nav-menu.component';
import { HomeComponent } from './temp/home/home.component';
import { CounterComponent } from './temp/counter/counter.component';
import { FetchDataComponent } from './temp/fetch-data/fetch-data.component';
import { GameComponent } from './game/game/game.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    GameModule,
    RouterModule.forRoot([
      { path: '', component: GameComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
    ])
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
