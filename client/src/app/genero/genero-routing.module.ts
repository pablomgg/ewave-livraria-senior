import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { GeneroComponent } from "./genero.component";

const routes: Routes = [
  {
    path: "",
    component: GeneroComponent,
    data: {
      title: "Generos",
    },
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class GeneroRoutingModule {}
