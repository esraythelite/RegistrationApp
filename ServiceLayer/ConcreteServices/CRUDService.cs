using DomainLayer.Entities;
using DomainLayer.RegistrationContext;
using RepositoryLayer.AbstractRepositories;
using RepositoryLayer.ConcreteRepositories;
using ServiceLayer.AbstractServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.ConcreteServices
{
    public class CRUDService<T>:ICRUDService<T> where T:BaseEntity
    {
        private readonly ICRUDRepository<T> genericRepository;

        public CRUDService(ICRUDRepository<T> genericRepository)
        {
            this.genericRepository = genericRepository;        
        }

        public void Add(T entity)
        {
            if (entity != null) genericRepository.Add(entity);
        }

        public void Delete(T entity)
        {
            genericRepository.Delete(entity);
        }

        public void Update(T entity)
        {
            genericRepository.Update(entity);
        }
    }
}
