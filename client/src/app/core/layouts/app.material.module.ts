import { LOCALE_ID, NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { MatSlideToggleModule } from "@angular/material/slide-toggle";
import { MatMenuModule } from "@angular/material/menu";
import { MatSidenavModule } from "@angular/material/sidenav";
import { MatSnackBarModule } from "@angular/material/snack-bar";
import { MatSliderModule } from "@angular/material/slider";
import { MAT_DATE_LOCALE } from "@angular/material/core";
import { MatExpansionModule } from "@angular/material/expansion";
import { MatButtonModule } from "@angular/material/button";
import { MatToolbarModule } from "@angular/material/toolbar";
import { MatTooltipModule } from "@angular/material/tooltip";
import { MatListModule } from "@angular/material/list";

import ptBr from "@angular/common/locales/pt";
import { registerLocaleData } from "@angular/common";

registerLocaleData(ptBr);

@NgModule({
  imports: [
    CommonModule,
    MatSlideToggleModule,
    MatMenuModule,
    MatSidenavModule,
    MatSnackBarModule,
    MatSliderModule,
    MatExpansionModule,
    MatButtonModule,
    MatToolbarModule,
    MatListModule,
    MatTooltipModule
  ],
  exports: [
    MatSlideToggleModule,
    MatMenuModule,
    MatSidenavModule,
    MatSnackBarModule,
    MatSliderModule,
    MatExpansionModule,
    MatButtonModule,
    MatToolbarModule,
    MatListModule,
    MatTooltipModule
  ],
  providers: [
    { provide: LOCALE_ID, useValue: "pt" },
    { provide: MAT_DATE_LOCALE, useValue: "pt-BR" },
  ],
})
export class AppMaterialModule {}
