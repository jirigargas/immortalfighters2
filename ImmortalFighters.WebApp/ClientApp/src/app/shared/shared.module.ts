import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RulesToReadableStringPipe } from './pipes/rules-to-readable-string.pipe';
import { DrdClassToReadableStringPipe } from './pipes/drd-class-to-readable-string.pipe';
import { DrdRaceToReadableStringPipe } from './pipes/drd-race-to-readable-string.pipe';
import { MatPaginatorIntl } from '@angular/material/paginator';
import { IfMatPaginatorIntl } from './if-mat-paginator-intl';

@NgModule({
  declarations: [
    RulesToReadableStringPipe,
    DrdClassToReadableStringPipe,
    DrdRaceToReadableStringPipe
  ],
  imports: [
    CommonModule
  ],
  exports: [
    RulesToReadableStringPipe,
    DrdClassToReadableStringPipe,
    DrdRaceToReadableStringPipe
  ],
  providers: [{ provide: MatPaginatorIntl, useClass: IfMatPaginatorIntl}],
})
export class SharedModule { }
