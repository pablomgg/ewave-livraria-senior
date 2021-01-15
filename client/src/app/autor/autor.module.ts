import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AutorRoutingModule } from './autor-routing.module';
import { AutorComponent } from './autor.component';


@NgModule({
  declarations: [AutorComponent],
  imports: [
    CommonModule,
    AutorRoutingModule
  ]
})
export class AutorModule { }
