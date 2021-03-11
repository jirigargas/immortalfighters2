import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UsersApiService } from './services/users-api.service';
import { HttpClientModule } from '@angular/common/http';



@NgModule({
  declarations:[ ],
  imports: [
    CommonModule,
    HttpClientModule
  ],
  providers: [
    UsersApiService
  ]
})
export class CoreModule { }
