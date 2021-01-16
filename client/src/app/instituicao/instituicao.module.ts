import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";

import { InstituicaoRoutingModule } from "./instituicao-routing.module";

import { InstituicaoConsultaComponent } from "./instituicao-consulta/instituicao-consulta.component";
import { InstituicaoCadastroComponent } from "./instituicao-cadastro/instituicao-cadastro.component";
import { SharedModule } from "../shared/shared.module";

@NgModule({
  declarations: [InstituicaoConsultaComponent, InstituicaoCadastroComponent],
  imports: [CommonModule, InstituicaoRoutingModule, SharedModule],
})
export class InstituicaoModule {}
