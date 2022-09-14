using DomainLayer.Entities;
using RepositoryLayer.AbstractRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.AbstractServices
{
    public interface IUserService: ICRUDService<User>
    {

    }
}
