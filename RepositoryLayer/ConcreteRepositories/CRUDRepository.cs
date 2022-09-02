using DomainLayer.Entities;
using DomainLayer.RegistrationContext;
using RepositoryLayer.AbstractRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.ConcreteRepositories
{
    public class CRUDRepository<T>:ICRUDRepository<T> where T: class
    {
        private readonly Context context;

        public CRUDRepository(Context context)
        {
            this.context = context;
        }

        public void Add(T entity)
        {
            try
            {
                context.Set<T>().AddAsync(entity);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Delete(T entity)
        {
            //try
            //{
            //    var deletedEntity = context.Set<T>().SingleOrDefault(e => e.Id == entity.Id);
            //    //context.Remove(deletedEntity);
            //    ////TODO// removeasync?
            //    //context.SaveChanges();
            //}
            //catch (Exception ex)
            //{

            //    Console.WriteLine(ex.Message);
            //}
        }

        public void Update(T entity)
        {
            //try
            //{
            //    var updatedEntity = context.Set<T>().SingleOrDefault(e => e.Id == entity.Id);
            //    //context.Update(updatedEntity);
            //    context.SaveChanges();
            //}
            //catch (Exception ex)
            //{

            //    Console.WriteLine(ex.Message);
            //}
        }
    }
}
