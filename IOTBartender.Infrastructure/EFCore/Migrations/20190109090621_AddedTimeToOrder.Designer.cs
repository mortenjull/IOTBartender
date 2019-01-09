﻿// <auto-generated />
using System;
using IOTBartender.Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace IOTBartender.Infrastructure.EFCore.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20190109090621_AddedTimeToOrder")]
    partial class AddedTimeToOrder
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("IOTBartender.Domain.Entititeis.Component", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FluidId");

                    b.Property<int>("RecipeId");

                    b.Property<int>("Size");

                    b.HasKey("Id");

                    b.HasIndex("FluidId");

                    b.HasIndex("RecipeId");

                    b.ToTable("Component");
                });

            modelBuilder.Entity("IOTBartender.Domain.Entititeis.Fluid", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Fluid");
                });

            modelBuilder.Entity("IOTBartender.Domain.Entititeis.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("RecipeId");

                    b.Property<int>("Status");

                    b.Property<DateTime>("Time");

                    b.HasKey("Id");

                    b.HasIndex("RecipeId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("IOTBartender.Domain.Entititeis.Recipe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Recipe");
                });

            modelBuilder.Entity("IOTBartender.Domain.Entititeis.Component", b =>
                {
                    b.HasOne("IOTBartender.Domain.Entititeis.Fluid", "Fluid")
                        .WithMany("Components")
                        .HasForeignKey("FluidId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("IOTBartender.Domain.Entititeis.Recipe", "Recipe")
                        .WithMany("Components")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("IOTBartender.Domain.Entititeis.Order", b =>
                {
                    b.HasOne("IOTBartender.Domain.Entititeis.Recipe", "Recipe")
                        .WithMany("Orders")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
