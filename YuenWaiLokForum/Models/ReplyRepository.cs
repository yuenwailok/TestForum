using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YuenWaiLokForum.Models.Abstract;

namespace YuenWaiLokForum.Models
{
    public class ReplyRepository: Repository<Reply>, IReplyRepository
    {
        public ReplyRepository(ForumModel _forumModel)
            : base (_forumModel)
        {
        }

        public IEnumerable<Reply> GetAllByF_Id(int id)
        {
            return _forumModel.Replies.Where(x => x.F_Id == id).ToList();
        }

        public IEnumerable<Reply> GetAllByT_Id(int id)
        {
            return _forumModel.Replies.Where(x => x.T_Id == id).ToList();

        }

        public ForumModel ForumModel
        {
            get { return _forumModel as ForumModel; }
        }
    }
}