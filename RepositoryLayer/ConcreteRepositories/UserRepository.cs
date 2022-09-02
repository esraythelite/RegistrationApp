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
    public class UserRepository : CRUDRepository<User>,IUserRepository
    {
        private readonly Context context;

        public UserRepository(Context context):base(context)
        {
            this.context = context;
        }

        public string GetUserFullName(User user)
        {
            try
            {
                return user.FirstName + " " + user.LastName;
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }
    }
}
