using AutoMapper;
using Pets_And_Paws_Api.App.Domain.Repositories;
using Pets_And_Paws_Api.App.Infrastructure.Database;
using Pets_And_Paws_Api.App.Infrastructure.Repositories;

namespace Pets_And_Paws_Api.App.Infrastructure.UnitOfWork;

public class UnitOfWork(DatabaseContext context, IMapper mapper) : IUnitOfWork
{
  private readonly DatabaseContext _context = context;
  private readonly IMapper _mapper = mapper;

  private IUserRepository? _users;
  public IUserRepository Users => _users ??= new UserRepository(_context, _mapper);

  private IResetTokenRepository? _tokens;
  public IResetTokenRepository Tokens => _tokens ??= new ResetTokenRepository(_context);

  private IRoleRepository? _roles;
  public IRoleRepository Roles => _roles ??= new RoleRepository(_context);
}