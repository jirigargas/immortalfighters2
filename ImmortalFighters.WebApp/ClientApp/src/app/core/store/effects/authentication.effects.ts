import { Injectable } from "@angular/core";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { AuthenticationStoreTypes, SignedIn, SignIn, SignUp } from "../actions/authentication.actions";
import { map, switchMap, tap } from "rxjs/operators";
import { UserApiService } from "../../services/user-api.service";
import { Router } from "@angular/router";
import { SnackbarService } from "../../services/snackbar.service";

@Injectable({ providedIn: 'root' })
export class AuthenticationEffects {
    constructor(
        private actions$: Actions,
        private userApi: UserApiService,
        private router: Router,
        private snackbarService: SnackbarService) {
    }

    $signUp = createEffect(
        () => this.actions$.pipe(
            ofType(AuthenticationStoreTypes.signUp),
            map((x: SignUp) => x.payload),
            switchMap(x => this.userApi.register(x)),
            tap(() => this.snackbarService.notifySuccess("A je to! Zaregistrovali jsem tě!")),
            tap(() => this.router.navigate(['/authentication/signin']))
        ),
        { dispatch: false }
    );

    $signIn = createEffect(
        () => this.actions$.pipe(
            ofType(AuthenticationStoreTypes.signIn),
            map((x: SignIn) => x.payload),
            switchMap(x => this.userApi.login(x)),
            switchMap(x => [new SignedIn(x)])
        )
    );

    $signedIn = createEffect(
        () => this.actions$.pipe(
            ofType(AuthenticationStoreTypes.signedIn),
            tap(() => this.router.navigate(['/main']))
        ),
        { dispatch: false }
    )

    $signOut = createEffect(
        () => this.actions$.pipe(
            ofType(AuthenticationStoreTypes.signOut),
            tap(() => this.router.navigate(['/']))
        ),
        { dispatch: false }
    )
}