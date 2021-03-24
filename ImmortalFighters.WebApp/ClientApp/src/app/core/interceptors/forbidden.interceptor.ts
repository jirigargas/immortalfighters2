import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor, HttpErrorResponse } from '@angular/common/http';
import { EMPTY, Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { SnackbarService } from '../services/snackbar.service';

@Injectable({
    providedIn: 'root'
})
export class ForbiddenInterceptor implements HttpInterceptor {

    constructor(private snackbarService: SnackbarService) {
    }

    intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
        return next.handle(request).pipe(
            catchError((error: HttpErrorResponse) => {
                if (error.status === 403) {
                    this.snackbarService.notifyError("Tak to teda ne, tohle nemáš povoleno!");
                    return EMPTY;
                } else {
                    return throwError (error);
                }
            })
        );
    }
}

