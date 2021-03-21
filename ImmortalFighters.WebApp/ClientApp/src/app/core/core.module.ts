import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { StoreModule } from '@ngrx/store';
import { reducers, metaReducers } from './store/app-state';
import { EffectsModule } from '@ngrx/effects';
import { AuthenticationEffects } from './store/effects/authentication.effects';
import { AppendTokenInterceptor } from './interceptors/append-token.interceptor';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { UnauthorizedInterceptor } from './interceptors/unauthorized.interceptor';
import { BadRequestInterceptor } from './interceptors/bad-request.interceptor';
import { ForbiddenInterceptor } from './interceptors/forbidden.interceptor';

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    HttpClientModule,
    MatSnackBarModule,
    StoreModule.forRoot(reducers, { metaReducers }),
    EffectsModule.forRoot([
      AuthenticationEffects
    ])
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AppendTokenInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: ForbiddenInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: UnauthorizedInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: BadRequestInterceptor, multi: true }
  ]
})
export class CoreModule { }
