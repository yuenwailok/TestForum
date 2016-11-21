using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YuenWaiLokForum.Models
{
    public class ReplyViewModel
    {
        public int id { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public int? LinkedReply_id { get; set; }
        public List<ReplyViewModel> replies { get; set; }
        public bool Added { get; set; }

    }
}