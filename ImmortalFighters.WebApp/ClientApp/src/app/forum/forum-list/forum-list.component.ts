import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Observable } from 'rxjs';
import { switchMap, tap } from 'rxjs/operators';
import { Forum } from '../../core/models/forum-models';
import { ForumApiService } from '../../core/services/forum-api.service';
import { SnackbarService } from '../../core/services/snackbar.service';
import { CreateForumComponent } from '../create-forum/create-forum.component';

@Component({
  selector: 'app-forum-list',
  templateUrl: './forum-list.component.html',
  styleUrls: ['./forum-list.component.scss']
})
export class ForumListComponent implements OnInit {

  forums$!: Observable<Forum[]>;

  constructor(private forumApi: ForumApiService,
    private snackbarService: SnackbarService,
    public dialog: MatDialog,) { }

  ngOnInit(): void {
    this.forums$ = this.forumApi.getAll();
  }

  onClickCreateForum() {
    var dialog = this.dialog.open(CreateForumComponent);
    dialog.afterClosed()
      .pipe(
        switchMap(x => this.forumApi.createNewForum(x)),
        tap(x => this.snackbarService.notifySuccess("Fórum " + x.name + " vytvořeno!"))
      )
      .subscribe();
  }
}