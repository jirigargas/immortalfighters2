import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ForumRoutingModule } from './forum-routing.module';
import { ForumComponent } from './forum.component';
import { SharedModule } from '../shared/shared.module';
import { ForumListComponent } from './forum-list/forum-list.component';
import { ForumDetailComponent } from './forum-detail/forum-detail.component';
import { MatListModule } from '@angular/material/list';


@NgModule({
  declarations: [ForumComponent, ForumListComponent, ForumDetailComponent],
  imports: [
    CommonModule,
    ForumRoutingModule,
    MatListModule,
    SharedModule
  ]
})
export class ForumModule { }
