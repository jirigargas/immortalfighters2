import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { DungeonComponent } from './dungeon.component';

const routes: Routes = [{ path: '', component: DungeonComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class DungeonRoutingModule { }
