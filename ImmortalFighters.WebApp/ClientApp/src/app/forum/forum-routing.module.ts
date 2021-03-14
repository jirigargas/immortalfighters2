import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ForumDetailComponent } from './forum-detail/forum-detail.component';
import { ForumListComponent } from './forum-list/forum-list.component';

import { ForumComponent } from './forum.component';

const routes: Routes = [{
  path: '', component: ForumComponent, children: [
    { path: '', component: ForumListComponent },
    { path: ':id', component: ForumDetailComponent }
  ]
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ForumRoutingModule { }
