import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";

import { LivroRoutingModule } from "./livro-routing.module";
import { LivroComponent } from "./livro.component";
import { SharedModule } from "../shared/shared.module";

@NgModule({
  declarations: [LivroComponent],
  imports: [CommonModule, LivroRoutingModule, SharedModule],
})
export class LivroModule {}
