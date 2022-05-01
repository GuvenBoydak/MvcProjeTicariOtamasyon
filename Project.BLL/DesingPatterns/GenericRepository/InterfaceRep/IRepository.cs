using Project.ENTITIES.Concrete.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.DesingPatterns.GenericRepository.InterfaceRep
{
    public interface IRepository<T> where T :BaseEntity
    {
        List<T> GetAll(); 
        List<T> GetActives();
        List<T> GetPassives(); 
        List<T> GetModifieds(); 

        //Modification Commands
        void Add(T item);
        void Update(T item);

        void SetActive(T item);


        /// <summary>
        /// Bu metot argüman olarak verdiginiz veriyi pasife ceker
        /// </summary>
        /// <param name="item">Pasife cekilecek olan veri</param>
        void Delete(T item);

        /// <summary>
        /// Bu metot argüman olarak verdiginiz veriyi siler
        /// </summary>
        /// <param name="item">Silinmesini istediginiz veri</param>
        void Destroy(T item);

        //Linq Expressions

        List<T> Where(Expression<Func<T, bool>> exp);
        bool Any(Expression<Func<T, bool>> exp);
        T FirstOrDefault(Expression<Func<T, bool>> exp);
        object Select(Expression<Func<T, object>> exp);
        int Count();
        int Sum(Expression<Func<T, int>> exp);

        // Find Commands

        T Find(int id);
    }
}
