using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspektJob.DataAccess
{
    public  interface IRepository<T>
    {
        void Create(T entity);
        List<T> GetAll();
        void Delete(int id);
        void Update(T entity);
    }
}
