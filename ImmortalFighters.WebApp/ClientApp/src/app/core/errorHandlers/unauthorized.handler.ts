import { HttpErrorResponse } from "@angular/common/http";
import { ErrorHandler, Injectable } from "@angular/core";
import { Store } from "@ngrx/store";
import { SignOut } from "../store/actions/authentication.actions";

@Injectable({
    providedIn: 'root'
})
export class UnauthorizedErrorHandler implements ErrorHandler {

    constructor(private store: Store) { }

    handleError(error: Error) {
        if (error instanceof HttpErrorResponse && error.status === 401) {
            console.warn("unhandled unauthorized response - signing out", error)
            this.store.dispatch(new SignOut());
        } else {
            throw (error)
        }
    }
}