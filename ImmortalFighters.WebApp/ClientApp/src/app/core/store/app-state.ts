import { ActionReducer, ActionReducerMap, MetaReducer } from "@ngrx/store";
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

export const debugActions = (reducer: ActionReducer<any>): ActionReducer<any> => (state, action) => {
    // eslint-disable-next-line no-console
    console.debug('action', action);
    return reducer(state, action);
};

export const debugState = (reducer: ActionReducer<any>): ActionReducer<any> => (state, action) => {
    // eslint-disable-next-line no-console
    console.debug('state', state);
    return reducer(state, action);
};

export const metaReducers: Array<MetaReducer<any, any>> = [debugState, debugActions];
