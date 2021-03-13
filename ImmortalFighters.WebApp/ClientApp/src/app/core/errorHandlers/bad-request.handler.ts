
import { HttpErrorResponse } from "@angular/common/http";
import { ErrorHandler, Injectable } from "@angular/core";
import { MatSnackBar } from '@angular/material/snack-bar';

@Injectable()
export class BadRequestErrorHandler implements ErrorHandler {

    constructor(private snackBar: MatSnackBar) { }

    handleError(error: Error) {
        if (error instanceof HttpErrorResponse && error.status === 400) {
            this.snackBar.open("A sakra! " + error.error, "OK", {
                duration: 3000,
                panelClass: ['red-snackbar'],
                horizontalPosition: "center",
                verticalPosition: "bottom",
              })
        } else {
            throw (error)
        }
    }
}