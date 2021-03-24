import { Inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Role } from '../models/role-models';

@Injectable({
    providedIn: 'root'
})
export class RoleApiService {

    constructor(private httpClient: HttpClient,
        @Inject('BASE_URL') private baseUrl: string) { }

    getAll(): Observable<Role[]> {
        return this.httpClient.get<Role[]>(this.baseUrl + "Role");
    }

}
