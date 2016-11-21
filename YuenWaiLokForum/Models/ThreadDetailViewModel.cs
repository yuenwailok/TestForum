using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YuenWaiLokForum.Models
{
    public class ThreadDetailViewModel
    {
        public string Author { get; set; }
        public string Topic { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public List<ReplyViewModel> replies { get; set; }
    }
}