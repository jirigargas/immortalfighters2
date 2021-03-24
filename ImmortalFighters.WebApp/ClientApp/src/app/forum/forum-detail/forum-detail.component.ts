import { Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Store } from '@ngrx/store';
import { QuillEditorComponent } from 'ngx-quill';
import { Observable, PartialObserver } from 'rxjs';
import { map, share, switchMap, tap } from 'rxjs/operators';
import { ForumEntries, ForumEntry } from '../../core/models/forum-models';
import { ForumEntryApiService } from '../../core/services/forum-entry-api.service';
import { AppState } from '../../core/store/app-state';
import { getUsername } from '../../core/store/reducers/authentication.reducer';

@Component({
  selector: 'app-forum-detail',
  templateUrl: './forum-detail.component.html',
  styleUrls: ['./forum-detail.component.scss']
})
export class ForumDetailComponent implements OnInit {

  forumId: number = -1;
  forumName$: Observable<string>;
  forumEntries$: Observable<ForumEntries>;
  currentUser$: Observable<string>;
  newForumEntryContent: any;
  newForumEntryModel: any;

  editingEntry: ForumEntry | undefined;

  @ViewChild("forumEntryEditor") forumEntryEditor!: QuillEditorComponent;

  crudObserver: PartialObserver<any> = {
    next: x => {
      this.forumEntries$ = this.getForumEntries();
      this.newForumEntryModel = "";
      this.editingEntry = undefined;
    },
  };

  constructor(private route: ActivatedRoute, private forumEntryApi: ForumEntryApiService, private store: Store<AppState>) {
    this.currentUser$ = this.store.select(getUsername);
    this.forumName$ = this.route.queryParamMap.pipe(map(x => x.get('name') ?? ""));
    this.forumEntries$ = this.getForumEntries();
  }

  getForumEntries(): Observable<ForumEntries> {
    return this.route.paramMap
      .pipe(
        map(params => parseInt(params.get('id') ?? "")),
        tap(forumId => this.forumId = forumId),
        switchMap(forumId => this.forumEntryApi.get(forumId, 0, 10)),
        share()
      );
  }

  ngOnInit() {

  }

  onContentChanged(event: any) {
    this.newForumEntryContent = event.content;
  }

  createNewEntry() {
    if (this.newForumEntryContent) {
      var text = JSON.stringify(this.newForumEntryContent);

      if (this.editingEntry) {
        this.forumEntryApi
          .patch({ forumEntryId: this.editingEntry.forumEntryId, text })
          .subscribe(this.crudObserver);
      } else {
        this.forumEntryApi
          .post({ forumId: this.forumId, text: text })
          .subscribe(this.crudObserver);
      }
    }
  }

  deleteEntry(entry: ForumEntry) {
    this.forumEntryApi
      .delete(entry.forumEntryId)
      .subscribe(this.crudObserver);
  }

  editEntry(entry: ForumEntry) {
    this.editingEntry = entry;
    var jsonText = JSON.parse(entry.text);
    this.forumEntryEditor.quillEditor.setContents(jsonText);
    (this.forumEntryEditor.elementRef.nativeElement as HTMLElement)?.scrollIntoView()
  }

}
