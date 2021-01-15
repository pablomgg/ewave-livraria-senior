import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { EmprestimoRoutingModule } from './emprestimo-routing.module';
import { EmprestimoComponent } from './emprestimo.component';


@NgModule({
  declarations: [EmprestimoComponent],
  imports: [
    CommonModule,
    EmprestimoRoutingModule
  ]
})
export class EmprestimoModule { }
