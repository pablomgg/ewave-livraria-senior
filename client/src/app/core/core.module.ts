import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { RouterModule } from "@angular/router";
import { AppMaterialModule } from "./layouts/app.material.module";
import { AppLayoutComponent } from "./layouts/app-layout/app-layout.component";
import { HTTP_INTERCEPTORS } from "@angular/common/http";
import { ErrorInterceptor } from "./auth/error-interceptor";

@NgModule({
  declarations: [AppLayoutComponent],
  imports: [CommonModule, RouterModule, AppMaterialModule],
  exports: [AppMaterialModule, AppLayoutComponent],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
  ],
})
export class CoreModule {}
