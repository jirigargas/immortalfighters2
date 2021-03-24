import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor, HttpErrorResponse } from '@angular/common/http';
import { EMPTY, Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { SnackbarService } from '../services/snackbar.service';

@Injectable({
    providedIn: 'root'
})
export class BadRequestInterceptor implements HttpInterceptor {

    constructor(private snackbarService: SnackbarService) {
    }

    intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
        return next.handle(request).pipe(
            catchError((error: HttpErrorResponse) => {
                if (error.status === 400) {
                    console.warn("bad request intercepted", error)
                    this.snackbarService.notifyError("A sakra! " + error.error);
                    return EMPTY;
                } else {
                    return throwError (error);
                }
            })
        );
    }
}

