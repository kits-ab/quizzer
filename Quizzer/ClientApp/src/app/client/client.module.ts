import { NgModule } from '@angular/core';
import { CommonModule } from "@angular/common";

import { ClientService } from './client.service';
import { ClientComponent } from './client/client.component';

@NgModule({
  declarations: [
    ClientComponent
  ],
  imports: [
    CommonModule
  ],
  exports: [
    ClientComponent
  ],
  providers: [
    ClientService
  ]
})
export class ClientModule { }
