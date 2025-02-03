using System;
using TodoApi.Application.Commons;
using TodoApi.Domain.Commons;

namespace TodoApi.Application.Interfaces;

public interface IUserService<Tdto> : IBaseApiService<Tdto>
    where Tdto : BaseDto
{

}
