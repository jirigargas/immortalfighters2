import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-authentication',
  template: `
  authentication
  <router-outlet></router-outlet>
  `,
  styles: [  ]
})
export class AuthenticationComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

}
