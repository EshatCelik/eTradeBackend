using eTradeBackend.Application.Repositories.MenuRepository;
using eTradeBackend.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTradeBackend.Persistance.Repositories.MenuRepository
{
    public class MenuWriteRepository : WriteRepository<Domain.Entities.Menu>, IMenuWriteRepository
    {
        public MenuWriteRepository(eTradeDbContext eTradeDbContext) : base(eTradeDbContext)
        {
        }
    }
}
