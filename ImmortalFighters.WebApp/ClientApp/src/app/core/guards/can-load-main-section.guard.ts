import { Injectable } from '@angular/core';
import { UrlTree, CanLoad, Route, UrlSegment, Router } from '@angular/router';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { AppState } from '../store/app-state';
import { getToken } from '../store/reducers/authentication.reducer';

@Injectable({
  providedIn: 'root'
})
export class CanLoadMainSectionGuard implements CanLoad {
  constructor(private store: Store<AppState>, private router: Router) {
  }

  canLoad(route: Route, segments: UrlSegment[]): boolean | UrlTree | Observable<boolean | UrlTree> | Promise<boolean | UrlTree> {
    return this.store.select(getToken).pipe(
      map(token => {
        if (token && token !== "") {
          return true;
        }
        else {
          return this.router.parseUrl("/authentication/signin");
        }
      }));
  }

}
