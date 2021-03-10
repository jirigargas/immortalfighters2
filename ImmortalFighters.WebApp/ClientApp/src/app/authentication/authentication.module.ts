import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AuthenticationRoutingModule } from './authentication-routing.module';
import { AuthenticationComponent } from './authentication.component';
import { SignInFormComponent } from './sign-in-form/sign-in-form.component';
import { SignUpFormComponent } from './sign-up-form/sign-up-form.component';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';

@NgModule({
  declarations: [AuthenticationComponent, SignInFormComponent, SignUpFormComponent],
  imports: [
    CommonModule,
    AuthenticationRoutingModule,
    MatCardModule,
    MatButtonModule
  ]
})
export class AuthenticationModule { }
