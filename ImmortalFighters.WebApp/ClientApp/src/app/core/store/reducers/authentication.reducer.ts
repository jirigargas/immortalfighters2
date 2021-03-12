import { Action, createSelector } from "@ngrx/store";
import { AuthenticationStoreTypes, SignedIn } from "../actions/authentication.actions";
import { AppState, AuthenticationState } from "../app-state"

const initialState: AuthenticationState = {
    token: "",
    username: ""
}

export const authenticationReducer = (state = initialState, action: Action): AuthenticationState => {
    switch (action.type) {
        case AuthenticationStoreTypes.signedIn:
            var response = (action as SignedIn).payload;
            return { ...state, token: response.token, username: response.username }
        default:
            return state;
    }
}

export const selectAuthenticationState = (appState: AppState) => appState.authenticationState;
export const getToken = createSelector(selectAuthenticationState, (x: AuthenticationState) => x.token);
export const getUsername = createSelector(selectAuthenticationState, (x: AuthenticationState) => x.username);
