import { Component, OnInit } from '@angular/core';
import { Observable, PartialObserver } from 'rxjs';
import { CharacterResponse } from '../../core/models/character-models';
import { CharacterApiService } from '../../core/services/character-api.service';

@Component({
  selector: 'app-my-characters',
  templateUrl: './my-characters.component.html',
  styleUrls: ['./my-characters.component.scss']
})
export class MyCharactersComponent implements OnInit {

  characters$: Observable<CharacterResponse[]>;
  createNewCharacterObserver: PartialObserver<CharacterResponse> = {
    next: x => this.characters$ = this.characters$ = this.characterApi.getMyCharacters(),
  };

  constructor(private characterApi: CharacterApiService) { 
    this.characters$ = this.characterApi.getMyCharacters();
  }

  ngOnInit(): void {
  }

  createNewDrdCharacter(){
    this.characterApi.createNewDrdCharacter().subscribe(this.createNewCharacterObserver);
  }

}
