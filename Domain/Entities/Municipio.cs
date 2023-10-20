using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities;

public class Municipio : BaseEntity
{
    public string Nombre { get; set; }
    public int DepartamentoId { get; set; }
    public Departamento Departamento { get; set; }
    ICollection<Empleado> Empleados { get; set; }
    ICollection<Cliente> Clientes { get; set; }
    ICollection<Empresa> Empresas { get; set; }

}
