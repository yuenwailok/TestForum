using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YuenWaiLokForum.Models.Abstract;

namespace YuenWaiLokForum.Models
{
    public class Repository<TEntity>: IRepository<TEntity> where TEntity : class
    {
        protected readonly ForumModel _forumModel;

        public Repository(ForumModel forumModel)
        {
            _forumModel = forumModel;
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _forumModel.Set<TEntity>().ToList();
        }


        public TEntity GetById(int id)
        {
            return _forumModel.Set<TEntity>().Find(id);
        }

        public void Add(TEntity tEntity)
        {
            _forumModel.Set<TEntity>().Add(tEntity);
            _forumModel.SaveChanges();
        }

        public void Remove(int id)
        {
            var removeEntity = GetById(id);
            _forumModel.Set<TEntity>().Remove(removeEntity);
            _forumModel.SaveChanges();
        }
    }
}