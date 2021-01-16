import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";

import { UsuarioRoutingModule } from "./usuario-routing.module";
import { SharedModule } from "../shared/shared.module";

import { UsuarioCadastroComponent } from "./usuario-cadastro/usuario-cadastro.component";
import { UsuarioConsultaComponent } from "./usuario-consulta/usuario-consulta.component";

@NgModule({
  declarations: [UsuarioCadastroComponent, UsuarioConsultaComponent],
  imports: [CommonModule, UsuarioRoutingModule, SharedModule],
})
export class UsuarioModule {}
