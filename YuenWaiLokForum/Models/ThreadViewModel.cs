using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YuenWaiLokForum.Models
{
    public class ThreadViewModel
    {
        public string ThreadName { get; set; }
        public string Author { get; set; }
        public DateTime Date { get; set; }
        public int TotalPosts { get; set; }
    }
}