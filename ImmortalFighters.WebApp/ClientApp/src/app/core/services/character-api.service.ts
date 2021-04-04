import { Inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { DrdCharacterDetailResponse, CharacterResponse, NewDrdCharacter } from '../models/character-models';

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

    getDrdCharacterDetails(characterId: number): Observable<DrdCharacterDetailResponse> {
        return this.httpClient.get<DrdCharacterDetailResponse>(this.baseUrl + "Character/GetDrdCharacter/" + characterId);
    }

    setAvatar(value: FormData): Observable<any> {
        return this.httpClient.post(this.baseUrl + "Character/UploadAvatar", value, { reportProgress: true });
    }


}
