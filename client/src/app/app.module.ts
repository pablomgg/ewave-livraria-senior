import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";

import { AppRoutingModule } from "./app-routing.module";
import { AppComponent } from "./app.component";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { CoreModule } from "./core/core.module";
import { HttpClientModule } from "@angular/common/http";
import { InstituicaoComponent } from './instituicao/instituicao.component';

@NgModule({
  declarations: [AppComponent, InstituicaoComponent],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    CoreModule,
  ],
  exports: [
    CoreModule
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
