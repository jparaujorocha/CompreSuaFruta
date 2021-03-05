using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using CompreSuaFruta.Dal.Context.Entities;

namespace CompreSuaFruta.Dal.Context.Contexts
{
    public class ProdutoDbContext : DbContext
    {
        public DbSet<Produto> Vendas { get; set; }

        public ProdutoDbContext(DbContextOptions<ProdutoDbContext> options) : base(options)
        { }
        protected override void OnModelCreating(ModelBuilder modelBuider)
        {
            base.OnModelCreating(modelBuider);
        }

    }
}
