using Project.BLL.DesingPatterns.GenericRepository.InterfaceRep;
using Project.BLL.DesingPatterns.SingeltonPattern;
using Project.DAL.Concrete.Context;
using Project.ENTITIES.Concrete.Entities;
using Project.ENTITIES.Concrete.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.DesingPatterns.GenericRepository.BaseRep
{
    public abstract class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected ProjeContext _db;
        public BaseRepository()
        {
            _db = DBTool.DbInstance;
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Add(T item)
        {
            _db.Set<T>().Add(item);
            Save();
        }

        public bool Any(Expression<Func<T, bool>> exp)
        {
            return _db.Set<T>().Any(exp);
        }

        public void Delete(T item)
        {
            item.DeletedDate = DateTime.Now;
            item.Status = DataStatus.Deleted;
            Save();
        }

        public void Destroy(T item)
        {
            _db.Set<T>().Remove(Find(item.ID));
            Save();
        }

        public T Find(int id)
        {
            return _db.Set<T>().Find(id);
        }

        public T FirstOrDefault(Expression<Func<T, bool>> exp)
        {
            return _db.Set<T>().FirstOrDefault(exp);
        }

        public List<T> GetActives()
        {
            return Where(x => x.Status != DataStatus.Deleted);
        }

        public List<T> GetAll()
        {
            return _db.Set<T>().ToList();
        }

        public List<T> GetModifieds()
        {
            return Where(x => x.Status == DataStatus.Updated);
        }

        public List<T> GetPassives()
        {
            return Where(x => x.Status == DataStatus.Deleted);
        }

        public object Select(Expression<Func<T, object>> exp)
        {
            return _db.Set<T>().Select(exp).ToList();
        }

        public void SetActive(T item)
        {
            item.Status = DataStatus.Inserted;
            item.ModifiedDate = DateTime.Now;

            Save();
        }

        public void Update(T item)
        {
            item.ModifiedDate = DateTime.Now;
            item.Status = DataStatus.Updated;
            T guncellenecek = Find(item.ID);
          
            _db.Entry(guncellenecek).CurrentValues.SetValues(item);
            Save();
        }

        public List<T> Where(Expression<Func<T, bool>> exp)
        {
            return _db.Set<T>().Where(exp).ToList();
        }
    }
}
