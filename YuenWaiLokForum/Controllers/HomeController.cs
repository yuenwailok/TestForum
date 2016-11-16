using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YuenWaiLokForum.Models;

namespace YuenWaiLokForum.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            var entities = new ForumModel();
            var forums = new List<ForumViewModel>();
            foreach (var forum in entities.Forums.ToList())
            {
                var query1 = (from thread in entities.Threads
                              where forum.F_Id == thread.F_Id
                              select thread.Author);

                var query2 = from reply in entities.Replies
                             where forum.F_Id == reply.F_Id
                             select reply.Author;

                var result = query1.Concat(query2);

                var result2 = result.Distinct();
                forums.Add(new ForumViewModel
                {
                    Name = forum.Name,
                    Description = forum.Description,
                    TotalPosts = query1.Count(),                    
                    TotalParticipants = result2.Count()
                });
            }
            
            return View(forums);
        }

        public ActionResult ThreadList()
        {
            var entities = new ForumModel();
            var threads = new List<ThreadViewModel>();
            foreach (var thread in entities.Threads.ToList())
            {
                threads.Add(new ThreadViewModel
                {
                    ThreadName = thread.ThreadName,
                    Author = thread.Author,
                    Date = thread.Date,
                    TotalPosts = (from reply in entities.Replies
                                  where thread.T_Id == reply.T_Id
                                  select reply).Count()
                });
            }
            return View(threads);
        }

        public ActionResult Thread()
        {
            return View();
        }

        public ActionResult Reply()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}