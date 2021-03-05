﻿// <auto-generated />
using System;
using CompreSuaFruta.Dal.Context.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CompreSuaFruta.Dal.Migrations.VendaDb
{
    [DbContext(typeof(VendaDbContext))]
    [Migration("20210305193633_migrations")]
    partial class migrations
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113");

            modelBuilder.Entity("CompreSuaFruta.Dal.Context.Entities.Venda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Data");

                    b.Property<int>("IdStatus");

                    b.Property<int>("IdUsuario");

                    b.Property<double>("Valor");

                    b.Property<bool>("VendaAtiva");

                    b.HasKey("Id");

                    b.ToTable("Vendas");
                });
#pragma warning restore 612, 618
        }
    }
}