import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RulesToReadableStringPipe } from './pipes/rules-to-readable-string.pipe';

@NgModule({
  declarations: [RulesToReadableStringPipe],
  imports: [
    CommonModule
  ],
  exports: [RulesToReadableStringPipe]
})
export class SharedModule { }
