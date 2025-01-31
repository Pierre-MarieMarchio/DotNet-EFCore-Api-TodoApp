using System;
using TodoApi.Bases;
using TodoApi.Interfaces;
using TodoApi.Models;

namespace TodoApi.Repositories;

public class UserRepository : BaseRdepository<User>, IUserRepository
{
    public UserRepository(TodoContext context) : base(context)
    {
    }
}
