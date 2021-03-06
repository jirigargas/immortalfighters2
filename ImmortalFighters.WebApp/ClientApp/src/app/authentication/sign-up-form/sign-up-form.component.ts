import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Store } from '@ngrx/store';
import { SignUp } from '../../core/store/actions/authentication.actions';
import { InvalidStateMatcher } from '../../shared/invalid-state-matcher';

@Component({
  selector: 'app-sign-up-form',
  templateUrl: './sign-up-form.component.html',
  styleUrls: ['./sign-up-form.component.scss']
})
export class SignUpFormComponent implements OnInit {

  form = new FormGroup({
    email: new FormControl('', [Validators.required, Validators.email,]),
    username: new FormControl('', [Validators.required, Validators.minLength(4)]),
    password: new FormControl('', [Validators.required, Validators.minLength(8)])
  });

  matcher = new InvalidStateMatcher();

  constructor(private store: Store) { }

  ngOnInit(): void {
  }

  onSubmit() {
    if (!this.form.valid) return;

    this.store.dispatch(new SignUp(this.form.value))
  }

}
