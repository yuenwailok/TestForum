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

        public ActionResult Test()
        {
            return View();
        }

        public ActionResult About()
        {
            var forums = new List<ForumViewModel>();

            using (var unitOfWork = new UnitOfWork(new ForumModel()))
            {
                foreach (var forum in unitOfWork.Forums.GetAll())
                {
                    forums.Add(new ForumViewModel
                    {
                        Name = forum.Name,
                        Description = forum.Description,
                        TotalPosts = unitOfWork.Replies.GetAllByF_Id(forum.F_Id).Count(),
                        TotalParticipants = unitOfWork.TotalParticipants(forum)
                    });

                }
            }
            return View(forums);
        }

        public ActionResult ThreadList()
        {
            var threads = new List<ThreadViewModel>();
            using (var unitOfWork = new UnitOfWork(new ForumModel()))
            {
                foreach (var thread in unitOfWork.Threads.GetAllByF_Id(5))
                {
                    threads.Add(new ThreadViewModel
                    {
                        ThreadName = thread.ThreadName,
                        Author = thread.Author,
                        Date = thread.Date,
                        TotalPosts = unitOfWork.Replies.GetAllByT_Id(thread.T_Id).Count()
                    });

                }

            }
            return View(threads);
        }

        public ActionResult Thread(int id = 0)
        {
            using (var unitOfWork = new UnitOfWork(new ForumModel()))
            {
                var th = unitOfWork.Threads.GetById(1);

                var threadDetail = new ThreadDetailViewModel
                {
                    Author = th.Author,
                    Content = th.Content,
                    Date = th.Date,
                    Topic = th.ThreadName,
                    replies = new List<ReplyViewModel>()
                };

                ReplyService rs = new ReplyService();
                rs.insertReply(th, threadDetail);

                return View(threadDetail);
            }
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