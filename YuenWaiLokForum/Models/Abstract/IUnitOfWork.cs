using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YuenWaiLokForum.Models.Abstract
{
    public interface IUnitOfWork: IDisposable
    {
        IForumRepository Forums { get; }
        IThreadRepository Threads { get; }
        IReplyRepository Replies { get; }

    }
}
