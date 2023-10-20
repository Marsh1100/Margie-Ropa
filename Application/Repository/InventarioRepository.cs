using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace Application.Repository;

public class InventarioRepository : GenericRepository<Inventario>, IInventario
{
    private readonly ApiDbContext _context;

    public InventarioRepository(ApiDbContext context) : base(context)
    {
       _context = context;
    }
}
