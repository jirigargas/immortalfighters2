import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Store } from '@ngrx/store';
import { AppState } from '../store/app-state';
import { switchMap } from 'rxjs/operators';
import { getToken } from '../store/reducers/authentication.reducer';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AppendTokenInterceptor implements HttpInterceptor {

  constructor(private store: Store<AppState>, private router: Router) {
  }

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    return this.store.select(getToken).pipe(
      switchMap(token => {
        if (token !== "") {
          request = request.clone({ setHeaders: { Authorization: `Bearer ${token}` } });
        }
        return next.handle(request);
      })
    )
  }
}

