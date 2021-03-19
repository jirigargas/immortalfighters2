import { Injectable } from "@angular/core";
import { MatSnackBar } from "@angular/material/snack-bar";

@Injectable({
    providedIn: 'root'
})
export class SnackbarService {

    constructor(private snackbar: MatSnackBar) { }

    public notifyError(message: string): void {
        this.snackbar.open(message, undefined, {
            duration: 3000,
            panelClass: ['failed-snackbar'],
            horizontalPosition: "center",
            verticalPosition: "bottom",
        });
    }

    public notifySuccess(message: string): void {
        this.snackbar.open(message, undefined, {
            duration: 3000,
            panelClass: ['succeeded-snackbar'],
            horizontalPosition: "center",
            verticalPosition: "bottom",
        });
    }
}
