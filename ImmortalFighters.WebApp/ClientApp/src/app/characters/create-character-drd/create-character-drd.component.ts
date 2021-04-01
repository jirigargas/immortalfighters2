import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { DrdPovolani, DrdRasa, NewDrdCharacter } from '../../core/models/character-models';
import { InvalidStateMatcher } from '../../shared/invalid-state-matcher';

@Component({
  selector: 'app-create-character-drd',
  templateUrl: './create-character-drd.component.html',
  styleUrls: ['./create-character-drd.component.scss']
})
export class CreateCharacterDrdComponent implements OnInit {

  form = new FormGroup({
    name: new FormControl('', [Validators.required]),
    race: new FormControl('', [Validators.required]),
    class: new FormControl('', [Validators.required]),
    conviction: new FormControl('', [Validators.required])
  });

  
  matcher = new InvalidStateMatcher();

  constructor(private dialogRef: MatDialogRef<CreateCharacterDrdComponent>) { }

  ngOnInit(): void {
  }

  onSubmit() {
    if (this.form.valid) {
      var req = new NewDrdCharacter();
      req.name = this.form.controls.name.value;
      req.race = Number(this.form.controls.race.value);
      req.class = Number(this.form.controls.class.value);
      req.conviction = Number(this.form.controls.conviction.value);
      this.dialogRef.close(req);
    }
  }
}
