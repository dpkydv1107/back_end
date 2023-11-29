using Domainlayer.Data;
using Domainlayer.Model;
using Microsoft.EntityFrameworkCore;
using Repositorylayer.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorylayer.Repository
{
    public class Repository <T> : IRepository<T> where T : CurrentYear
    {
        #region property
        private readonly ApplicationDbContext _applicationDbContext;
        private DbSet<T> entities;
        #endregion
        #region Constructor
        public Repository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
            entities = _applicationDbContext.Set<T>();
        }
        #endregion
        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            _applicationDbContext.SaveChanges();
        }
        public T Get(int Id)
        {
            return entities.SingleOrDefault(c => c.Id == Id);
        }
        public IEnumerable<T> GetCurrentYearDataByEmployeeName(string EmployeeName)
        {
            return entities.Cast<T>().Where(data => data.Employee_name == EmployeeName).ToList();
        }
        public IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable();
        }
       
        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            _applicationDbContext.SaveChanges();
        }
        public void Remove(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
        }
        public void SaveChanges()
        {
            _applicationDbContext.SaveChanges();
        }
        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Update(entity);
            _applicationDbContext.SaveChanges();
        }

        public IEnumerable<T> GetCurrentYearDataByEmployeeName(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
