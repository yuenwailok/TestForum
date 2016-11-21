using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YuenWaiLokForum.Models.Abstract
{
    public interface IThreadRepository : IRepository<Thread>
    {
        IEnumerable<Thread> GetAllByF_Id(int F_id);

        IEnumerable<Thread> GetAllById(int id);
    }
}
