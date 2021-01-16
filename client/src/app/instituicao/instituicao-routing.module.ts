import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";

import { InstituicaoCadastroComponent } from "./instituicao-cadastro/instituicao-cadastro.component";
import { InstituicaoConsultaComponent } from "./instituicao-consulta/instituicao-consulta.component";

const routes: Routes = [
  {
    path: "",
    component: InstituicaoConsultaComponent,
  },
  {
    path: "cadastrar",
    component: InstituicaoCadastroComponent,
  },
  {
    path: ":id/editar",
    component: InstituicaoCadastroComponent,
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class InstituicaoRoutingModule {}
