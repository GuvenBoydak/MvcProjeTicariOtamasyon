using Project.DAL.Concrete.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.DesingPatterns.SingeltonPattern
{
    public class DBTool
    {
        DBTool() { }

        static ProjeContext _dbInstance;

        public static ProjeContext DbInstance 
        {
            get
            {
                if (_dbInstance==null)
                {
                    _dbInstance = new ProjeContext();
                }
                return _dbInstance;
            }
         }
    }
}
