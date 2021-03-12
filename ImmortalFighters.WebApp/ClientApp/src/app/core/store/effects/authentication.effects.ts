import { Injectable } from "@angular/core";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { AuthenticationStoreTypes, SignedIn, SignIn, SignUp } from "../actions/authentication.actions";
import { map, switchMap, tap } from "rxjs/operators";
import { UsersApiService } from "../../services/users-api.service";
import { Router } from "@angular/router";

@Injectable()
export class AuthenticationEffects {
    constructor(
        private actions$: Actions,
        private usersApi: UsersApiService,
        private router: Router) {
    }

    $signUp = createEffect(
        () => this.actions$.pipe(
            ofType(AuthenticationStoreTypes.signUp),
            map((x: SignUp) => x.payload),
            switchMap(x => this.usersApi.register(x)),
            tap(() => this.router.navigate(['/authentication/signin']))
        ),
        { dispatch: false }
    );

    $signIn = createEffect(
        () => this.actions$.pipe(
            ofType(AuthenticationStoreTypes.signIn),
            map((x: SignIn) => x.payload),
            switchMap(x => this.usersApi.login(x)),
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
}