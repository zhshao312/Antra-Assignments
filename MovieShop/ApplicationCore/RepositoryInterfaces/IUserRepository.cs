﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Entities;

namespace ApplicationCore.RepositoryInterfaces
{
    public interface IUserRepository: IAsyncRepository<User>
    {
        Task<User> GetUserbyEmail(string email);

        Task<User> GetUserById(int id);
    }
}
