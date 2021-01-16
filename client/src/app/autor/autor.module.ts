import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";

import { AutorRoutingModule } from "./autor-routing.module";
import { AutorComponent } from "./autor.component";
import { SharedModule } from "../shared/shared.module";

@NgModule({
  declarations: [AutorComponent],
  imports: [CommonModule, AutorRoutingModule, SharedModule],
})
export class AutorModule {}
