using CompreSuaFruta.Model.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompreSuaFruta.Dal.Context.Contexts
{
    public class VendaDbContext : DbContext
    {
        public DbSet<Venda> Venda { get; set; }

        public VendaDbContext(DbContextOptions<VendaDbContext> options) : base(options)
        { }
        protected override void OnModelCreating(ModelBuilder modelBuider)
        {
            base.OnModelCreating(modelBuider);
        }

    }
}
