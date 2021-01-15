import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { InstituicaoComponent } from "./instituicao.component";

const routes: Routes = [
  {
    path: "",
    component: InstituicaoComponent,
    data: {
      title: "Instituições de ensino",
    },
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class InstituicaoRoutingModule {}
