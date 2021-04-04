import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';
import { map, share, switchMap, tap } from 'rxjs/operators';
import { CharacterDetailResponse } from '../../core/models/character-models';
import { CharacterApiService } from '../../core/services/character-api.service';

@Component({
  selector: 'app-drd-character-detail',
  templateUrl: './drd-character-detail.component.html',
  styleUrls: ['./drd-character-detail.component.scss']
})
export class DrdCharacterDetailComponent implements OnInit {
  avatarForm = new FormGroup({
    file: new FormControl('', [Validators.required]),
  });

  selectedFile: File | undefined = undefined;
  charactedId: number = -1;
  character$: Observable<CharacterDetailResponse>

  constructor(private route: ActivatedRoute, private characterApi: CharacterApiService) {
    this.character$ = this.getCharacter();
  }

  getCharacter(): Observable<CharacterDetailResponse> {
    return this.route.paramMap
      .pipe(
        map(params => parseInt(params.get('id') ?? "")),
        tap(x => this.charactedId = x),
        switchMap(characterId => this.characterApi.getDrdCharacterDetails(characterId)),
        share()
      );
  }

  ngOnInit(): void {
  }

  onAvatarSubmit() {
    if (this.avatarForm.valid && this.selectedFile) {
      const formData = new FormData();
      formData.append('CharacterId', this.charactedId.toString());
      formData.append('file', this.selectedFile, this.selectedFile.name);

      this.characterApi.setAvatar(formData).subscribe();
    }
  }

  onFileChange(event: any) {
    if (event.target.files.length > 0) {
      this.selectedFile = <File>event.target.files[0];
    }
  }

}
