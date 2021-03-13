import { ActionReducerMap, MetaReducer } from "@ngrx/store";
import { authenticationReducer } from "./reducers/authentication.reducer";

export interface AppState {
    authenticationState: AuthenticationState;
}

export interface AuthenticationState {
    token: string;
    username: string;
}

export const reducers: ActionReducerMap<AppState> = {
    authenticationState: authenticationReducer
}

export const metaReducers: Array<MetaReducer<any, any>> = [];