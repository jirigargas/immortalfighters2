import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CharactersRoutingModule } from './characters-routing.module';
import { CharactersComponent } from './characters.component';
import { MyCharactersComponent } from './my-characters/my-characters.component';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { SharedModule } from '../shared/shared.module';


@NgModule({
  declarations: [
    CharactersComponent,
    MyCharactersComponent
  ],
  imports: [
    CommonModule,
    CharactersRoutingModule,
    SharedModule,
    MatButtonModule,
    MatCardModule
  ]
})
export class CharactersModule { }
