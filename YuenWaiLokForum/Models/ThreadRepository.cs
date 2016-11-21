using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YuenWaiLokForum.Models.Abstract;

namespace YuenWaiLokForum.Models
{
    public class ThreadRepository : Repository<Thread>, IThreadRepository
    {

        public ThreadRepository(ForumModel _forumModel)
            : base (_forumModel)
        {
        }

        public IEnumerable<Thread> GetAllByF_Id(int F_id)
        {
            return _forumModel.Threads.Where(x => x.F_Id == F_id).ToList();
        }

        public IEnumerable<Thread> GetAllById(int id)
        {
            return _forumModel.Threads.Where(x => x.T_Id == id).ToList();
        }

        public ForumModel ForumModel
        {
            get { return _forumModel as ForumModel; }
        }


    }    
}