import { Action } from "@ngrx/store";
import { SignInRequest, SignInResponse, SignUpRequest } from "../../models/authentication-models";

export enum AuthenticationStoreTypes {
    signUp = '[AuthenticationStoreTypes] SignUp',
    signIn = '[AuthenticationStoreTypes] SignIn',
    signedIn = '[AuthenticationStoreTypes] SignedIn',
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

export class SignedIn implements Action {
    
    readonly type: AuthenticationStoreTypes;
    readonly payload: SignInResponse;

    constructor(signInResponse: SignInResponse) {
        this.type = AuthenticationStoreTypes.signedIn
        this.payload = signInResponse;
    }
}