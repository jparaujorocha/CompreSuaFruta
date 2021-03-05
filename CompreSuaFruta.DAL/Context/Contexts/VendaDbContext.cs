using CompreSuaFruta.Dal.Context.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompreSuaFruta.Dal.Context.Contexts
{
    public class VendaDbContext : DbContext
    {
        public DbSet<Venda> Vendas { get; set; }

        public VendaDbContext(DbContextOptions<VendaDbContext> options) : base(options)
        { }
        protected override void OnModelCreating(ModelBuilder modelBuider)
        {
            base.OnModelCreating(modelBuider);
        }

    }
}
