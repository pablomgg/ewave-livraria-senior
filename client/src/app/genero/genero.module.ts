import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { GeneroRoutingModule } from './genero-routing.module';
import { GeneroComponent } from './genero.component';


@NgModule({
  declarations: [GeneroComponent],
  imports: [
    CommonModule,
    GeneroRoutingModule
  ]
})
export class GeneroModule { }
