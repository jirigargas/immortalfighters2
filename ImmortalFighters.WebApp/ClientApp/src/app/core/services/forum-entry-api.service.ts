import { Inject, Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ForumEntry } from '../models/forum-models';

@Injectable({
    providedIn: 'root'
})
export class ForumEntryApiService {

    constructor(private httpClient: HttpClient,
        @Inject('BASE_URL') private baseUrl: string) { }

    get(forumId: number, page: number, pageSize: number): Observable<ForumEntry[]> {
        debugger;
        let params = new HttpParams()
            .append('forumId', forumId.toString())
            .append('page', page.toString())
            .append('pageSize', pageSize.toString());

        return this.httpClient.get<ForumEntry[]>(this.baseUrl + "ForumEntry", { params: params });
    }
}
