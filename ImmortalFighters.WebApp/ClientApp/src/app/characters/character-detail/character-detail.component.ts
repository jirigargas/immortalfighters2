import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';
import { map, switchMap } from 'rxjs/operators';
import { CharacterApiService } from '../../core/services/character-api.service';

@Component({
  selector: 'app-character-detail',
  templateUrl: './character-detail.component.html',
  styleUrls: ['./character-detail.component.scss']
})
export class CharacterDetailComponent implements OnInit {

  character$: Observable<{}>

  constructor(private route: ActivatedRoute, private characterApi: CharacterApiService) {
    this.character$ = this.getCharacter();
  }

  getCharacter(): Observable<{}> {
    return this.route.paramMap
      .pipe(
        map(params => parseInt(params.get('id') ?? "")),
        switchMap(characterId => this.characterApi.getDetails(characterId)),
      );
  }

  ngOnInit(): void {
  }

}
