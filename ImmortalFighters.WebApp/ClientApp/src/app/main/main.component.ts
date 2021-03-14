import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Store } from '@ngrx/store';
import { SignOut } from '../core/store/actions/authentication.actions';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.scss']
})
export class MainComponent implements OnInit {

  constructor(private store: Store, private router: Router) { }

  ngOnInit(): void {
  }

  signOut() {
    this.store.dispatch(new SignOut());
    // this.router.navigate(['/']);

  }
}
