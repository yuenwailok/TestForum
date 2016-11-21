using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YuenWaiLokForum.Models.Abstract
{
    public interface IReplyRepository : IRepository<Reply>
    {
        IEnumerable<Reply> GetAllByF_Id(int id);

        IEnumerable<Reply> GetAllByT_Id(int id);

    }
}
