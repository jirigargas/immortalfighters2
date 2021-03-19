import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { Observable } from 'rxjs';
import { ForumApiService } from '../../core/services/forum-api.service';
import { InvalidStateMatcher } from '../../shared/invalid-state-matcher';

@Component({
  selector: 'app-create-forum',
  templateUrl: './create-forum.component.html',
  styleUrls: ['./create-forum.component.scss']
})
export class CreateForumComponent implements OnInit {

  form = new FormGroup({
    name: new FormControl('', [Validators.required]),
    category: new FormControl('', [Validators.required])
  });

  matcher = new InvalidStateMatcher();
  categories$: Observable<string[]>;

  constructor(private dialogRef: MatDialogRef<CreateForumComponent>, private forumApi: ForumApiService) {
    this.categories$ = this.forumApi.getAllCategories();
  }

  ngOnInit(): void {
  }

  onSubmit() {
    if (this.form.valid) {
      this.dialogRef.close(this.form.value);
    }
  }

}
