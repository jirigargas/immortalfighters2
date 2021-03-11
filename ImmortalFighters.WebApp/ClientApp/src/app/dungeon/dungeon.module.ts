import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { DungeonRoutingModule } from './dungeon-routing.module';
import { DungeonComponent } from './dungeon.component';
import { SharedModule } from '../shared/shared.module';


@NgModule({
  declarations: [DungeonComponent],
  imports: [
    CommonModule,
    DungeonRoutingModule, 
    SharedModule
  ]
})
export class DungeonModule { }
