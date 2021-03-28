import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NewCharacterFormComponent } from './new-character-form/new-character-form.component';



@NgModule({
  declarations: [
    NewCharacterFormComponent
  ],
  imports: [
    CommonModule
  ],
  exports: [
    NewCharacterFormComponent
  ]
})
export class DraciDoupeModule { }
