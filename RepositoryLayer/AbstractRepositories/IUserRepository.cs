using DomainLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.AbstractRepositories
{
    public interface IUserRepository:ICRUDRepository<User>
    {
        string GetUserFullName(User user);
    }
}
