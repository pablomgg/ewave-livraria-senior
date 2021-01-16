import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";

import { EmprestimoRoutingModule } from "./emprestimo-routing.module";
import { EmprestimoComponent } from "./emprestimo.component";
import { SharedModule } from "../shared/shared.module";

@NgModule({
  declarations: [EmprestimoComponent],
  imports: [CommonModule, EmprestimoRoutingModule, SharedModule],
})
export class EmprestimoModule {}
