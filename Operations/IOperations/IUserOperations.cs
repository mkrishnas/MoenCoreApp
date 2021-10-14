using Models.Configuration;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Operations.IOperations
{
    public interface IUserOperations
    {

        Task<User> Authenticate(string username, string password, JWT key);

        Task<User> AddUser(string username, string password);

        Task<bool> AddRole(string rolename);

    }
}
