import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Store } from '@ngrx/store';
import { SignIn } from '../../core/store/actions/authentication.actions';
import { InvalidStateMatcher } from '../../shared/invalid-state-matcher';

@Component({
  selector: 'app-sign-in-form',
  templateUrl: './sign-in-form.component.html',
  styleUrls: ['./sign-in-form.component.scss']
})
export class SignInFormComponent implements OnInit {

  form = new FormGroup({
    email: new FormControl('', [Validators.required, Validators.email,]),
    password: new FormControl('', [Validators.required, Validators.minLength(8)])
  });

  matcher = new InvalidStateMatcher();

  constructor(private store: Store) { }

  ngOnInit(): void {
  }

  onSubmit() {
    if (!this.form.valid) return;

    this.store.dispatch(new SignIn(this.form.value))
  }

}
