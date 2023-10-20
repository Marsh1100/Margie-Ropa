using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Interfaces;

public interface IUnitOfWork
{
    IRolRepository Roles { get; }
    IUserRepository Users { get; }
    IProveedor Proveedores { get; }
    ITipoPersona TipoPersonas { get; }
    IMunicipio Municipios { get; }

    Task<int> SaveAsync();
}
