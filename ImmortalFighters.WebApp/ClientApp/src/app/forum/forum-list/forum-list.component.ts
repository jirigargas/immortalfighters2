import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { filter, switchMap, tap } from 'rxjs/operators';
import { ForumsGroupedByCategory } from '../../core/models/forum-models';
import { ForumApiService } from '../../core/services/forum-api.service';
import { SnackbarService } from '../../core/services/snackbar.service';
import { AppState } from '../../core/store/app-state';
import { getIsModerator } from '../../core/store/reducers/authentication.reducer';
import { CreateForumComponent } from '../create-forum/create-forum.component';

@Component({
  selector: 'app-forum-list',
  templateUrl: './forum-list.component.html',
  styleUrls: ['./forum-list.component.scss']
})
export class ForumListComponent implements OnInit {

  forumsGroupedByCategory$!: Observable<ForumsGroupedByCategory[]>;
  isForumAdministrator$: Observable<boolean>;

  constructor(private forumApi: ForumApiService,
    private snackbarService: SnackbarService,
    private store: Store<AppState>,
    public dialog: MatDialog) { 
      this.isForumAdministrator$ = this.store.select(getIsModerator);
    }

  ngOnInit(): void {
    this.forumsGroupedByCategory$ = this.forumApi.getAllGroupedByCategory();
    
  }

  onClickCreateForum() {
    var dialog = this.dialog.open(CreateForumComponent);
    dialog.afterClosed()
      .pipe(
        filter(x => !!x),
        switchMap(x => this.forumApi.createNewForum(x)),
        tap(x => this.snackbarService.notifySuccess("Fórum " + x.name + " vytvořeno!"))
      )
      .subscribe();
  }
}