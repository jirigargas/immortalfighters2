using System.Collections.Generic;

namespace ImmortalFighters.WebApp.ApiModels
{
    public class ForumsGroupedByCategory
    {
        public string Category { get; set; }
        public ICollection<ForumResponse> Forums { get; set; }
    }
}
