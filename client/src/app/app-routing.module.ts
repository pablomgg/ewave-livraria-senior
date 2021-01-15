import { NgModule } from "@angular/core";
import { PreloadAllModules, Routes, RouterModule } from "@angular/router";
import { AppLayoutComponent } from "./core/layouts/app-layout/app-layout.component";

const routes: Routes = [
  {
    path: "",
    redirectTo: "home",
    pathMatch: "full",
  },
  {
    path: "",
    component: AppLayoutComponent,
    children: [
      {
        path: "home",
        loadChildren: () => import(`./home/home.module`).then(m => m.HomeModule)
      },
      {
        path: "instituicao",
        loadChildren: () => import(`./instituicao/instituicao.module`).then(m => m.InstituicaoModule)
      },
      {
        path: "usuario",
        loadChildren: () => import(`./usuario/usuario.module`).then(m => m.UsuarioModule)
      },
      {
        path: "autor",
        loadChildren: () => import(`./autor/autor.module`).then(m => m.AutorModule)
      },
      {
        path: "genero",
        loadChildren: () => import(`./genero/genero.module`).then(m => m.GeneroModule)
      },
      {
        path: "livro",
        loadChildren: () => import(`./livro/livro.module`).then(m => m.LivroModule)
      },
      {
        path: "emprestimo",
        loadChildren: () => import(`./emprestimo/emprestimo.module`).then(m => m.EmprestimoModule)
      }
    ]
  }
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes, { preloadingStrategy: PreloadAllModules }),
  ],
  exports: [RouterModule],
})
export class AppRoutingModule {}
