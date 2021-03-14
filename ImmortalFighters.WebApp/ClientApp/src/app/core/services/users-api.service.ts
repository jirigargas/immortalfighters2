import { Inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { SignInRequest, SignInResponse, SignUpRequest } from '../models/authentication-models';

@Injectable({
  providedIn: 'root'
})
export class UsersApiService {

  constructor(private httpClient: HttpClient,
    @Inject('BASE_URL') private baseUrl: string) { }

  register(request: SignUpRequest): Observable<{}> {
    return this.httpClient.post(this.baseUrl + "Users/Register", request);
  }

  login(request: SignInRequest): Observable<SignInResponse> {
    return this.httpClient.post<SignInResponse>(this.baseUrl + "Users/Login", request);
  }
}
