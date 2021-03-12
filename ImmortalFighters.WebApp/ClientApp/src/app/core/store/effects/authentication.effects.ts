import { Injectable } from "@angular/core";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { AuthenticationStoreTypes, RegisterNewUser } from "../actions/authentication.actions";
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

    $registerNewUser = createEffect(
        () => this.actions$.pipe(
            ofType(AuthenticationStoreTypes.registerNewUser),
            map((x: RegisterNewUser) => x.payload),
            switchMap(x => this.usersApi.register(x)),
            tap(() => this.router.navigate(['/authentication/signin']))
        ),
        { dispatch: false }
    );
}