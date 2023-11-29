using Domainlayer.Model;
using Repositorylayer.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicelayer
{
    public class Service : IService<CurrentYear>
    {
        private readonly IRepository<CurrentYear> _currentyearRepository;
        public Service(IRepository<CurrentYear> employeeRepository)
        {
            _currentyearRepository = employeeRepository;
        }
        public void Delete(CurrentYear entity)
        {
            try
            {
                if (entity != null)
                {
                    _currentyearRepository.Delete(entity);
                    _currentyearRepository.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public CurrentYear Get(int Id)
        {
            try
            {
                var obj = _currentyearRepository.Get(Id);
                if (obj != null)
                {
                    return obj;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
       
        public IEnumerable<CurrentYear> GetAll()
        {
            try
            {
                var obj = _currentyearRepository.GetAll();
                if (obj != null)
                {
                    return obj;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void Insert(CurrentYear entity)
        {
            try
            {
                if (entity != null)
                {
                    _currentyearRepository.Insert(entity);
                    _currentyearRepository.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void Remove(CurrentYear entity)
        {
            try
            {
                if (entity != null)
                {
                    _currentyearRepository.Remove(entity);
                    _currentyearRepository.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void Update(CurrentYear entity)
        {
            try
            {
                if (entity != null)
                {
                    _currentyearRepository.Update(entity);
                    _currentyearRepository.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
