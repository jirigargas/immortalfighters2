import { ErrorHandler, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UsersApiService } from './services/users-api.service';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { StoreModule } from '@ngrx/store';
import { reducers, metaReducers } from './store/app-state';
import { EffectsModule } from '@ngrx/effects';
import { AuthenticationEffects } from './store/effects/authentication.effects';
import { AppendTokenInterceptor } from './interceptors/append-token.interceptor';
import { UnauthorizedErrorHandler } from './errorHandlers/unauthorized.handler';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { BadRequestErrorHandler } from './errorHandlers/bad-request.handler';



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
    UsersApiService,
    { provide: HTTP_INTERCEPTORS, useClass: AppendTokenInterceptor, multi: true },
    { provide: ErrorHandler, useClass: UnauthorizedErrorHandler },
    { provide: ErrorHandler, useClass: BadRequestErrorHandler }
  ]
})
export class CoreModule { }
