using eTradeBackend.Domain.Entities;
using eTradeBackend.Domain.Entities.Common;
using eTradeBackend.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTradeBackend.Persistance.Contexts
{
    public class eTradeDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public eTradeDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Domain.Entities.File> Files { get; set; }
        public DbSet<ProductImageFile> ProductImageFiles { get; set; }
        public DbSet <InvoiceFile> InvoiceFiles { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }
        public DbSet<CompletedOrder> CompletedOrder { get; set; }
        public DbSet<Menu>  Menus { get; set; }
        public DbSet<EndPoint> Endpoints { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Order>()
                .HasKey(o => o.Id);

            builder.Entity<Order>()
                .HasIndex(o => o.OrderCode)
                .IsUnique();
            builder.Entity<Basket>()
                .HasOne(b => b.Order)
                .WithOne(x => x.Basket)
                .HasForeignKey<Order>(b => b.Id);

            base.OnModelCreating(builder);

            builder.Entity<Order>()
                .HasOne(x=>x.CompletedOrder)
                .WithOne(x=>x.Order)
                .HasForeignKey<CompletedOrder>(b => b.Id);


        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var datas = ChangeTracker.Entries<BaseEntity>();
            foreach (var data in datas)
            {
                _ = data.State switch
                {
                    EntityState.Added => data.Entity.CreateDate = DateTime.UtcNow,
                    EntityState.Modified => data.Entity.UpdateDate = DateTime.UtcNow,
                    _ => DateTime.UtcNow
                };
            }
            return base.SaveChangesAsync(cancellationToken);

        }


    }
}
