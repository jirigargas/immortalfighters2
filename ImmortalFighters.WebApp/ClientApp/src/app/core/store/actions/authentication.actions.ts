import { Action } from "@ngrx/store";
import { SignInRequest, SignUpRequest } from "../../models/authentication-models";

export enum AuthenticationStoreTypes {
    signUp = '[AuthenticationStoreTypes] SignUp',
    signIn = '[AuthenticationStoreTypes] SignIn'
}

export class SignUp implements Action {
    
    readonly type: AuthenticationStoreTypes;
    readonly payload: SignUpRequest;

    constructor(registerRequest: SignUpRequest) {
        this.type = AuthenticationStoreTypes.signUp
        this.payload = registerRequest;
    }
}

export class SignIn implements Action {
    
    readonly type: AuthenticationStoreTypes;
    readonly payload: SignInRequest;

    constructor(signInRequest: SignInRequest) {
        this.type = AuthenticationStoreTypes.signIn
        this.payload = signInRequest;
    }
}