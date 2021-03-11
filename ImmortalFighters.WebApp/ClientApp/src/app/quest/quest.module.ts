import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { QuestRoutingModule } from './quest-routing.module';
import { QuestComponent } from './quest.component';
import { SharedModule } from '../shared/shared.module';

@NgModule({
  declarations: [QuestComponent],
  imports: [
    CommonModule,
    QuestRoutingModule,
    SharedModule
  ]
})
export class QuestModule { }
