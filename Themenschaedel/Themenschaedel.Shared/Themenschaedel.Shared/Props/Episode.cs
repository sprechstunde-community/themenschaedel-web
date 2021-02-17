using System;
using System.Collections.Generic;
using System.Text;

namespace Themenschaedel.Shared.Props
{
    public class Episode
    {
        public int id { get; set; }
        public string guid { get; set; }
        public int episode_number { get; set; }
        public string title { get; set; }
        public string subtitle { get; set; }
        public string description { get; set; }
        public string image { get; set; }
        public int duration { get; set; }
        public DateTimeOffset published_at { get; set; }
        public DateTimeOffset created_at { get; set; }
        public DateTimeOffset updated_at { get; set; }
        public List<Hosts> hosts { get; set; } = new List<Hosts>();
        public List<Topics> topics { get; set; } = new List<Topics>();
        public bool claimed { get; set; }
        public int upvotes { get; set; }
        public int downvotes { get; set; }
        public int flags { get; set; }
    }
}
