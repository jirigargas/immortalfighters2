import { Inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Forum, ForumsGroupedByCategory } from '../models/forum-models';

@Injectable({
    providedIn: 'root'
})
export class ForumApiService {

    constructor(private httpClient: HttpClient,
        @Inject('BASE_URL') private baseUrl: string) { }

    getAll(): Observable<Forum[]> {
        return this.httpClient.get<Forum[]>(this.baseUrl + "Forum");
    }

    getAllGroupedByCategory(): Observable<ForumsGroupedByCategory[]> {
        return this.httpClient.get<ForumsGroupedByCategory[]>(this.baseUrl + "Forum/GroupedByCategory");
    }

    getAllCategories(): Observable<string[]> {
        return this.httpClient.get<string[]>(this.baseUrl + "Forum/Categories");
    }

    createNewForum(newForum: Forum): Observable<Forum> {
        return this.httpClient.post<Forum>(this.baseUrl + "Forum", newForum);
    }

}
