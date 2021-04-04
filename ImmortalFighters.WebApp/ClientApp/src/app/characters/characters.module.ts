import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CharactersRoutingModule } from './characters-routing.module';
import { CharactersComponent } from './characters.component';
import { MyCharactersComponent } from './my-characters/my-characters.component';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { SharedModule } from '../shared/shared.module';
import { MatDialogModule } from '@angular/material/dialog';
import { CreateCharacterDrdComponent } from './create-character-drd/create-character-drd.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatInputModule, } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatSelectModule } from '@angular/material/select';
import { DrdCharacterDetailComponent } from './drd-character-detail/drd-character-detail.component';


@NgModule({
  declarations: [
    CharactersComponent,
    MyCharactersComponent,
    CreateCharacterDrdComponent,
    DrdCharacterDetailComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    CharactersRoutingModule,
    SharedModule,
    MatButtonModule,
    MatCardModule,
    MatDialogModule,
    MatInputModule,
    MatFormFieldModule,
    MatSelectModule
  ]
})
export class CharactersModule { }
