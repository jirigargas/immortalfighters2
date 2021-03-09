import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { DungeonRoutingModule } from './dungeon-routing.module';
import { DungeonComponent } from './dungeon.component';


@NgModule({
  declarations: [DungeonComponent],
  imports: [
    CommonModule,
    DungeonRoutingModule
  ]
})
export class DungeonModule { }
