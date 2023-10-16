using eTradeBackend.Application.Repositories.Files;
using eTradeBackend.Domain.Entities;
using eTradeBackend.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTradeBackend.Persistance.Repositories.FileRepository
{
    public class FileReadRepository : ReadRepository<Domain.Entities.File>, IFileReadRepository
    {
        public FileReadRepository(eTradeDbContext eTradeDbContext) : base(eTradeDbContext)
        {
        }
    }
}
