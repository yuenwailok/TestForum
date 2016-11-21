using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YuenWaiLokForum.Models.Abstract;

namespace YuenWaiLokForum.Models
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ForumModel _forumModel;
        public UnitOfWork(ForumModel forumModel)
        {
            _forumModel = forumModel;
            Forums = new ForumRepository(_forumModel);
            Threads = new ThreadRepository(_forumModel);
            Replies = new ReplyRepository(_forumModel);
        }

        public IForumRepository Forums { get; private set; }
        public IThreadRepository Threads { get; private set; }
        public IReplyRepository Replies { get; private set; }


        public void Dispose()
        {
            _forumModel.Dispose();
        }

        public int TotalParticipants(Forum forum)
        {
            List<string> authorList = new List<string>();

            foreach (var thread in Threads.GetAllByF_Id(forum.F_Id))
            {
                authorList.Add(thread.Author);
            }

            foreach (var reply in Replies.GetAllByF_Id(forum.F_Id))
            {
                authorList.Add(reply.Author);
            }


            return authorList.Distinct().Count();

        }

    }
}