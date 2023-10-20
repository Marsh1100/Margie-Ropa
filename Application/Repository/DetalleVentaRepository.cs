using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace Application.Repository;

public class DetalleVentaRepository : GenericRepository<DetalleVenta>, IDetalleVenta
{
    private readonly ApiDbContext _context;

    public DetalleVentaRepository(ApiDbContext context) : base(context)
    {
       _context = context;
    }
}
