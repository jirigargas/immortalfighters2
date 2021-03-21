export class Forum {
    forumId: number = -1;
    name: string = "";
    category: string = "";
}

export class ForumsGroupedByCategory {
    category: string = "";
    forums: Forum[] = [];
}

export class ForumEntry {
    forumEntryId: number = -1;
    text: string = "";
}
