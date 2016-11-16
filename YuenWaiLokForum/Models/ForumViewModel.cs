using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YuenWaiLokForum.Models
{
    public class ForumViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int TotalPosts { get; set; }
        public int TotalParticipants { get; set; }
    }
}