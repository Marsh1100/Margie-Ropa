using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Repository;
using Domain.Interfaces;
using Persistence;

namespace Application.UnitOfWork;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly ApiDbContext _context;
    private IRolRepository _roles;
    private IUserRepository _users;
    private IProveedor _proveedor;
    private ITipoPersona _tipoPersona;
    private IMunicipio _municipio;
  
    public UnitOfWork(ApiDbContext context)
    {
        _context = context;
    }
    public IMunicipio Municipios
    {
        get
        {
            if (_municipio == null)
            {
                _municipio = new MunicipioRepository(_context);
            }
            return _municipio;
        }
    }
    public ITipoPersona TipoPersonas
    {
        get
        {
            if (_tipoPersona == null)
            {
                _tipoPersona = new TipoPersonaRepository(_context);
            }
            return _tipoPersona;
        }
    }
    public IProveedor Proveedores
    {
        get
        {
            if (_proveedor == null)
            {
                _proveedor = new ProveedorRepository(_context);
            }
            return _proveedor;
        }
    }
    public IRolRepository Roles
    {
        get
        {
            if (_roles == null)
            {
                _roles = new RolRepository(_context);
            }
            return _roles;
        }
    }

    public IUserRepository Users
    {
        get
        {
            if (_users == null)
            {
                _users = new UserRepository(_context);
            }
            return _users;
        }
    }
    
    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}