using eTradeBackend.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTradeBackend.Persistance.Contexts
{
    public class eTradeDbContext:IdentityDbContext<AppUser>
    {
    }
}
