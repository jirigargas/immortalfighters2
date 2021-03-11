import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { UsersApiService } from '../../core/services/users-api.service';
import { InvalidStateMatcher } from '../../shared/invalid-state-matcher';

@Component({
  selector: 'app-sign-up-form',
  templateUrl: './sign-up-form.component.html',
  styleUrls: ['./sign-up-form.component.scss']
})
export class SignUpFormComponent implements OnInit {

  signupForm = new FormGroup({
    email: new FormControl('', [Validators.required, Validators.email,]),
    username: new FormControl('', [Validators.required, Validators.minLength(4)]),
    password: new FormControl('', [Validators.required, Validators.minLength(8)])
  });

  matcher = new InvalidStateMatcher();

  constructor(private usersApi: UsersApiService) { }

  ngOnInit(): void {
  }

  onSubmit() {
    if (!this.signupForm.valid) return;

    this.usersApi.register(this.signupForm.value).subscribe(() => console.log("registered"));
  }

}
