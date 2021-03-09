import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { QuestRoutingModule } from './quest-routing.module';
import { QuestComponent } from './quest.component';


@NgModule({
  declarations: [QuestComponent],
  imports: [
    CommonModule,
    QuestRoutingModule
  ]
})
export class QuestModule { }
