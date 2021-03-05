using CompreSuaFruta.Dal.Context.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompreSuaFruta.Dal.Context.Contexts
{
    public class StatusVendaDbContext : DbContext
    {
        public DbSet<StatusVenda> StatusVendas { get; set; }

        public StatusVendaDbContext(DbContextOptions<StatusVendaDbContext> options) : base(options)
        { }
        protected override void OnModelCreating(ModelBuilder modelBuider)
        {
            base.OnModelCreating(modelBuider);
        }

    }
}
