using Domainlayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorylayer.IRepository
{
    public interface IRepository <T> where T : CurrentYear
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> GetCurrentYearDataByEmployeeName(T entity);
        T Get(int Id);
    
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Remove(T entity);
        void SaveChanges();
       
    }
}
