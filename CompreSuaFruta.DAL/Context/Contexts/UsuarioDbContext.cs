using CompreSuaFruta.Model.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompreSuaFruta.Dal.Context.Contexts
{
    public class UsuarioDbContext : DbContext
    {
        public DbSet<Usuario> Usuario { get; set; }

        public UsuarioDbContext(DbContextOptions<UsuarioDbContext> options) : base(options)
        { }
        protected override void OnModelCreating(ModelBuilder modelBuider)
        {
            base.OnModelCreating(modelBuider);
        }
    }
}
