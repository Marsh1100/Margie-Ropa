using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace Application.Repository;

public class PrendaRepository : GenericRepository<Prenda>, IPrenda
{
    private readonly ApiDbContext _context;

    public PrendaRepository(ApiDbContext context) : base(context)
    {
       _context = context;
    }
}
