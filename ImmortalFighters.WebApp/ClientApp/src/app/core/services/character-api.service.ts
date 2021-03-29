import { Inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CharacterResponse } from '../models/character-models';

@Injectable({
    providedIn: 'root'
})
export class CharacterApiService {


    constructor(private httpClient: HttpClient,
        @Inject('BASE_URL') private baseUrl: string) { }

    getMyCharacters(): Observable<CharacterResponse[]> {
        return this.httpClient.get<CharacterResponse[]>(this.baseUrl + "Character");
    }

    createNewDrdCharacter(): Observable<CharacterResponse> {
        return this.httpClient.post<CharacterResponse>(this.baseUrl + "Character/CreateDrdCharacter",{});
    }


}
