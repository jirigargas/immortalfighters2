import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ForumRoutingModule } from './forum-routing.module';
import { ForumComponent } from './forum.component';
import { SharedModule } from '../shared/shared.module';
import { ForumListComponent } from './forum-list/forum-list.component';
import { ForumDetailComponent } from './forum-detail/forum-detail.component';
import { MatListModule } from '@angular/material/list';
import { MatButtonModule } from '@angular/material/button';
import { MatDialogModule } from '@angular/material/dialog';
import { CreateForumComponent } from './create-forum/create-forum.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { MatInputModule } from '@angular/material/input';
import { MatExpansionModule } from '@angular/material/expansion';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatCardModule } from '@angular/material/card';
import { QuillModule } from 'ngx-quill';


@NgModule({
  declarations: [ForumComponent, ForumListComponent, ForumDetailComponent, CreateForumComponent],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    ForumRoutingModule,
    MatListModule,
    MatButtonModule,
    MatDialogModule,
    MatAutocompleteModule,
    MatInputModule,
    MatExpansionModule,
    MatCheckboxModule,
    MatCardModule,
    SharedModule,
    QuillModule.forRoot({
      suppressGlobalRegisterWarning: true,
      readOnly: true,
      theme: 'snow',
      placeholder: 'Tady začni psát ...'
    })
  ]
})
export class ForumModule { }
