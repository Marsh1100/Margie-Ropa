using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace Application.Repository;

public class OrdenRepository : GenericRepository<Orden>, IOrden
{
    private readonly ApiDbContext _context;

    public OrdenRepository(ApiDbContext context) : base(context)
    {
       _context = context;
    }
}
