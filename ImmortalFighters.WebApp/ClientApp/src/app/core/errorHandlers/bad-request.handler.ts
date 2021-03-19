
import { HttpErrorResponse } from "@angular/common/http";
import { ErrorHandler, Injectable } from "@angular/core";
import { SnackbarService } from "../services/snackbar.service";

@Injectable({
    providedIn: 'root'
})
export class BadRequestErrorHandler implements ErrorHandler {

    constructor(private snackbarService: SnackbarService) { }

    handleError(error: Error) {
        if (error instanceof HttpErrorResponse && error.status === 400) {
            this.snackbarService.notifyError("A sakra! " + error.error);
        } else {
            throw (error);
        }
    }
}