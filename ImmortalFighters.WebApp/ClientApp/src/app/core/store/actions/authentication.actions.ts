import { Action } from "@ngrx/store";
import { RegisterRequest } from "../../models/register-request";

export enum AuthenticationStoreTypes {
    registerNewUser = '[AuthenticationStoreTypes] RegisterNewUser'
}

export class RegisterNewUser implements Action {
    
    readonly type: AuthenticationStoreTypes;
    readonly payload: RegisterRequest;

    constructor(registerRequest: RegisterRequest) {
        this.type = AuthenticationStoreTypes.registerNewUser
        this.payload = registerRequest;
    }
}