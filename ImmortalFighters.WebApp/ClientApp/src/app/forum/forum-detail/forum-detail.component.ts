import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';
import { map, switchMap } from 'rxjs/operators';
import { ForumEntry } from '../../core/models/forum-models';
import { ForumEntryApiService } from '../../core/services/forum-entry-api.service';

@Component({
  selector: 'app-forum-detail',
  templateUrl: './forum-detail.component.html',
  styleUrls: ['./forum-detail.component.scss']
})
export class ForumDetailComponent implements OnInit {

  forumName$: Observable<string>;
  forumEntries$: Observable<ForumEntry[]>;

  constructor(private route: ActivatedRoute, private forumEntryApi: ForumEntryApiService) {

    this.forumName$ = this.route.queryParamMap.pipe(map(x => x.get('name') ?? ""));
    this.forumEntries$ = this.route.paramMap
      .pipe(
        map(params => parseInt(params.get('id') ?? "")),
        switchMap(forumId => this.forumEntryApi.get(forumId, 0, 10))
      );
  }

  ngOnInit(): void {

  }

}
