﻿// <auto-generated />
using CompreSuaFruta.Dal.Context.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CompreSuaFruta.Dal.Migrations.UsuarioDb
{
    [DbContext(typeof(UsuarioDbContext))]
    [Migration("20210306145726_Migrations")]
    partial class Migrations
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113");

            modelBuilder.Entity("CompreSuaFruta.Model.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Cpf");

                    b.Property<string>("Nome");

                    b.Property<string>("Senha");

                    b.Property<bool>("UsuarioAtivo");

                    b.HasKey("Id");

                    b.ToTable("Usuario");
                });
#pragma warning restore 612, 618
        }
    }
}