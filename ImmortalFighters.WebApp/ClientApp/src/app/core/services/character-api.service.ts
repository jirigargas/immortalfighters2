import { Inject, Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CharacterDetailResponse, CharacterResponse, NewDrdCharacter } from '../models/character-models';

@Injectable({
    providedIn: 'root'
})
export class CharacterApiService {

    constructor(private httpClient: HttpClient,
        @Inject('BASE_URL') private baseUrl: string) { }

    getMyCharacters(): Observable<CharacterResponse[]> {
        return this.httpClient.get<CharacterResponse[]>(this.baseUrl + "Character");
    }

    createNewDrdCharacter(request: NewDrdCharacter): Observable<CharacterResponse> {
        return this.httpClient.post<CharacterResponse>(this.baseUrl + "Character/CreateDrdCharacter", request);
    }

    getDetails(characterId: number): Observable<CharacterDetailResponse> {
        return this.httpClient.get<CharacterDetailResponse>(this.baseUrl + "Character/" + characterId);
    }

    setAvatar(value: FormData) {
        return this.httpClient.post<{}>(this.baseUrl + "Character/UploadAvatar", value, { reportProgress: true });
    }


}
