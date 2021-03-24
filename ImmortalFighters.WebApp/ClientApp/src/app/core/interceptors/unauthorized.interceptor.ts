import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor, HttpErrorResponse } from '@angular/common/http';
import { EMPTY, Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { SignOut } from '../store/actions/authentication.actions';
import { Store } from '@ngrx/store';

@Injectable({
    providedIn: 'root'
})
export class UnauthorizedInterceptor implements HttpInterceptor {

    constructor(private store: Store) {
    }

    intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
        return next.handle(request).pipe(
            catchError((error: HttpErrorResponse) => {
                if (error.status === 401) {
                    console.warn("unauthorized response intercepted", error)
                    this.store.dispatch(new SignOut());
                    return EMPTY;
                } else {
                    return throwError(error);
                }
            })
        );
    }
}

