import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Forum } from '../../core/models/forum-models';
import { ForumApiService } from '../../core/services/forum-api.service';

@Component({
  selector: 'app-forum-list',
  templateUrl: './forum-list.component.html',
  styleUrls: ['./forum-list.component.scss']
})
export class ForumListComponent implements OnInit {

  forums$!: Observable<Forum[]>;

  constructor(private forumApi: ForumApiService) { }

  ngOnInit(): void {
    this.forums$ = this.forumApi.getAll();
  }

}
