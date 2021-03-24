import { Injectable } from '@angular/core';
import { UrlTree, CanLoad, Route, UrlSegment, Router } from '@angular/router';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CanLoadMainSectionGuard implements CanLoad {
  constructor(private router: Router) {
  }

  canLoad(route: Route, segments: UrlSegment[]): boolean | UrlTree | Observable<boolean | UrlTree> | Promise<boolean | UrlTree> {
    var state = localStorage.getItem("authenticationState") ?? "{}";
    var token = JSON.parse(state).token;
    if (token && token !== "") {
      return true;
    }
    else {
      return this.router.parseUrl("/authentication/signin");
    }
  }

}
