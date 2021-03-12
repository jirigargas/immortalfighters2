import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UsersApiService } from './services/users-api.service';
import { HttpClientModule } from '@angular/common/http';
import { StoreModule } from '@ngrx/store';
import { reducers, metaReducers } from './store/app-state';
import { EffectsModule } from '@ngrx/effects';
import { AuthenticationEffects } from './store/effects/authentication.effects';



@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    HttpClientModule,
    StoreModule.forRoot(reducers, { metaReducers }),
    EffectsModule.forRoot([
      AuthenticationEffects
    ])
  ],
  providers: [
    UsersApiService
  ]
})
export class CoreModule { }
