import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LivroComponent } from './livro.component';

const routes: Routes = [
  {
    path: "",
    component: LivroComponent,
    data: {
      title: "Livros",
    },
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class LivroRoutingModule { }
