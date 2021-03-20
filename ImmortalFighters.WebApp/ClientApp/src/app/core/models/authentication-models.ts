export class SignUpRequest {
    username: string = "";
    password: string = "";
    email: string = "";
}

export class SignInRequest {
    email: string = "";
    password: string = "";
}

export class SignInResponse {
    username: string = "";
    token: string = "";
    roles: string[] = [];
}
