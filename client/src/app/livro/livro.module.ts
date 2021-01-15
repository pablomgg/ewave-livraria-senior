import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { LivroRoutingModule } from './livro-routing.module';
import { LivroComponent } from './livro.component';


@NgModule({
  declarations: [LivroComponent],
  imports: [
    CommonModule,
    LivroRoutingModule
  ]
})
export class LivroModule { }
