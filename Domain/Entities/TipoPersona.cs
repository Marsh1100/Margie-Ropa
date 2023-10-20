using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities;

public class TipoPersona : BaseEntity
{
    public string Nombre { get; set; }
    ICollection<Cliente> Clientes { get; set; }
    ICollection<Proveedor> Proveedores { get; set; }

}
