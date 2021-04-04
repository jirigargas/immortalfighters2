import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Observable, PartialObserver } from 'rxjs';
import { map, share, switchMap, tap } from 'rxjs/operators';
import { DrdCharacterDetailResponse } from '../../core/models/character-models';
import { CharacterApiService } from '../../core/services/character-api.service';
import { SnackbarService } from '../../core/services/snackbar.service';

@Component({
  selector: 'app-drd-character-detail',
  templateUrl: './drd-character-detail.component.html',
  styleUrls: ['./drd-character-detail.component.scss']
})
export class DrdCharacterDetailComponent implements OnInit {
  character$: Observable<DrdCharacterDetailResponse>
  characterId: number = -1;

  characterChangedObserver: PartialObserver<void> = {
    next: () => {
      this.snacbarService.notifySuccess("Avatar byl změněn")
      this.character$ = this.getCharacter();
    }
  }

  constructor(private route: ActivatedRoute, private characterApi: CharacterApiService, private snacbarService: SnackbarService) {
    this.character$ = this.getCharacter();
  }

  getCharacter(): Observable<DrdCharacterDetailResponse> {
    return this.route.paramMap
      .pipe(
        map(params => parseInt(params.get('id') ?? "")),
        tap(x => this.characterId = x),
        switchMap(characterId => this.characterApi.getDrdCharacterDetails(characterId)),
        share()
      );
  }

  ngOnInit(): void {
  }


  onFileChange(event: any) {
    if (event.target.files.length > 0) {
      var selectedFile = <File>event.target.files[0];

      const formData = new FormData();
      formData.append('CharacterId', this.characterId.toString());
      formData.append('file', selectedFile, selectedFile.name);

      this.characterApi.setAvatar(formData).subscribe(this.characterChangedObserver);
    }
  }
}
