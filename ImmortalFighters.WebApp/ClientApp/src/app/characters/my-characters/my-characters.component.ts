import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Observable, PartialObserver } from 'rxjs';
import { filter, switchMap, tap } from 'rxjs/operators';
import { CharacterResponse } from '../../core/models/character-models';
import { CharacterApiService } from '../../core/services/character-api.service';
import { SnackbarService } from '../../core/services/snackbar.service';
import { CreateCharacterDrdComponent } from '../create-character-drd/create-character-drd.component';

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

  constructor(
    private characterApi: CharacterApiService,
    public dialog: MatDialog,
    private snackbarService: SnackbarService) {
    this.characters$ = this.characterApi.getMyCharacters();
  }

  ngOnInit(): void {
  }

  createNewDrdCharacter() {
    let dialog = this.dialog.open(CreateCharacterDrdComponent);
    dialog.afterClosed()
      .pipe(
        filter(x => !!x),
        switchMap(x => this.characterApi.createNewDrdCharacter(x)),
        tap(x => this.snackbarService.notifySuccess("Postava " + x.name + " byla vytvořena!")),
      )
      .subscribe(this.createNewCharacterObserver);
  }

}
