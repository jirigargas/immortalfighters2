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
    username: string = "";
    created: Date = new Date();
    changed: Date | undefined;
}

export class ForumEntries {
    totalCount: number = 0;
    page: number = 0;
    forumEntries: ForumEntry[] = []
}

export class createNewForumEntryRequest {
    forumId: number = -1;
    text: string = "";
}
