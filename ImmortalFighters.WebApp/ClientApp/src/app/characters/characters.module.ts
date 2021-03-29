import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CharactersRoutingModule } from './characters-routing.module';
import { CharactersComponent } from './characters.component';
import { SelectNewCharacterComponent } from './select-new-character/select-new-character.component';
import { MyCharactersComponent } from './my-characters/my-characters.component';
import { MatButtonModule } from '@angular/material/button';


@NgModule({
  declarations: [CharactersComponent, SelectNewCharacterComponent, MyCharactersComponent],
  imports: [
    CommonModule,
    CharactersRoutingModule, 
    MatButtonModule
  ]
})
export class CharactersModule { }
