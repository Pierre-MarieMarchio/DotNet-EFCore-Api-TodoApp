using System;
using TodoApi.Domain.Interfaces;
using TodoApi.Domain.Models;
using TodoApi.Infrastructur.Context;
using TodoApi.Infrastructure.Commons;


namespace TodoApi.Infrastructure.Repositories;

public class UserRepository(DatabaseContext context) : BaseRepository<User>(context), IUserRepository
{
}
