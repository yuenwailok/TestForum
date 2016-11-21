using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YuenWaiLokForum.Models.Abstract;

namespace YuenWaiLokForum.Models
{
    public class ForumRepository: Repository<Forum>, IForumRepository
    {

        public ForumRepository(ForumModel _forumModel)
            : base(_forumModel)
        {
        }

        public ForumModel ForumModel
        {
            get { return _forumModel as ForumModel; }
        }
    }
}