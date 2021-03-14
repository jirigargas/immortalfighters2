import { Inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Forum } from '../models/forum-models';

@Injectable({
    providedIn: 'root'
})
export class ForumApiService {

    constructor(private httpClient: HttpClient,
        @Inject('BASE_URL') private baseUrl: string) { }

    getAll(): Observable<Forum[]> {
        return this.httpClient.get<Forum[]>(this.baseUrl + "Forum");
    }

}
