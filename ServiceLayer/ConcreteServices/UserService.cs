using DomainLayer.Entities;
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
    public class UserService : CRUDService<User>,IUserService
    {
        private readonly IUserRepository userRepository;
        
        public UserService(IUserRepository userRepository):base(userRepository)
        {
            this.userRepository = userRepository;
        }

    }
}
