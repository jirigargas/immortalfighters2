using System.Collections.Generic;

namespace ImmortalFighters.WebApp.ApiModels
{
    public class ForumEntriesResponse
    {
        public int TotalCount { get; set; }
        public int Page { get; set; }
        public IEnumerable<ForumEntryResponse> ForumEntries { get; set; }
    }
}
