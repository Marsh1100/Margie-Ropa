using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace Application.Repository;

public class EmpleadoRepository : GenericRepository<Empleado>, IEmpleado
{
    private readonly ApiDbContext _context;

    public EmpleadoRepository(ApiDbContext context) : base(context)
    {
       _context = context;
    }
}
