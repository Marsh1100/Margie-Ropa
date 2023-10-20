using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities;

public class Color : BaseEntity
{
   public string Descripcion { get; set; }
   ICollection<DetalleOrden> DetalleOrdenes {get; set;}
    
}
