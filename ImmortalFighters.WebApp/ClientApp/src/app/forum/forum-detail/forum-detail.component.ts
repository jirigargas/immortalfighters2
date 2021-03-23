import { Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { QuillEditorComponent } from 'ngx-quill';
import { Observable, PartialObserver } from 'rxjs';
import { map, share, switchMap, tap } from 'rxjs/operators';
import { ForumEntries } from '../../core/models/forum-models';
import { ForumEntryApiService } from '../../core/services/forum-entry-api.service';

@Component({
  selector: 'app-forum-detail',
  templateUrl: './forum-detail.component.html',
  styleUrls: ['./forum-detail.component.scss']
})
export class ForumDetailComponent implements OnInit {

  forumId: number = -1;
  forumName$: Observable<string>;
  forumEntries$: Observable<ForumEntries>;
  newForumEntryContent: any;
  newForumEntryModel:any;

  createNewEntryObserver: PartialObserver<any> = {
    next: x => { 
      this.forumEntries$ = this.getForumEntries();
      this.newForumEntryModel = "";
    },
  };

  constructor(private route: ActivatedRoute, private forumEntryApi: ForumEntryApiService) {

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
      this.forumEntryApi
        .post({ forumId: this.forumId, text: text })
        .subscribe(this.createNewEntryObserver);
    }
  }

}
