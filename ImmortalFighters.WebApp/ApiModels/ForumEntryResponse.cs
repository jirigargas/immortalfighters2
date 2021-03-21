using System;

namespace ImmortalFighters.WebApp.ApiModels
{
    public class ForumEntryResponse
    {
        public int ForumEntryId { get; set; }
        public string UserName { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Changed { get; set; }
        public string Text { get; set; }
    }
}
