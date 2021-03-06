using CompreSuaFruta.Model.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompreSuaFruta.Dal.Context.Contexts
{
    public class ProdutoVendaDbContext : DbContext
    {
        public DbSet<ProdutoVenda> ProdutoVenda { get; set; }

        public ProdutoVendaDbContext(DbContextOptions<ProdutoVendaDbContext> options) : base(options)
        { }
        protected override void OnModelCreating(ModelBuilder modelBuider)
        {
            base.OnModelCreating(modelBuider);
        }

    }
}
