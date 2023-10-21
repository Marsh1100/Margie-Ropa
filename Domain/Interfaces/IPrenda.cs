using Domain.Entities;

namespace Domain.Interfaces;

    public interface IPrenda : IGenericRepository<Prenda> { 
       Task<IEnumerable<object>> GetPrendas(); 
    }

