using System.Linq.Expressions;
using Pets_And_Paws_Api.App.Application.DTOs.Responses.User;
using Pets_And_Paws_Api.App.Domain.Models;

namespace Pets_And_Paws_Api.App.Domain.Repositories;

public interface IUserRepository : IGenericRepository<User>
{
  Task<List<User>> ListAllUser();
  Task<User?> FindUserToAuth(string Email, string Name = "");
}