import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { MainComponent } from './main.component';

const routes: Routes = [
  {
    path: '', component: MainComponent, children: [
      { path: 'quest', loadChildren: () => import('../quest/quest.module').then(m => m.QuestModule) },
      { path: 'dungeon', loadChildren: () => import('../dungeon/dungeon.module').then(m => m.DungeonModule) },
      { path: 'forum', loadChildren: () => import('../forum/forum.module').then(m => m.ForumModule) }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class MainRoutingModule { }
