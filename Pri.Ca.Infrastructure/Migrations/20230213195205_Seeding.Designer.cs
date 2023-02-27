﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Pri.Ca.Infrastructure.Data;

#nullable disable

namespace Pri.Ca.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbcontext))]
    [Migration("20230213195205_Seeding")]
    partial class Seeding
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CategoryGame", b =>
                {
                    b.Property<int>("CategoriesId")
                        .HasColumnType("int");

                    b.Property<int>("GamesId")
                        .HasColumnType("int");

                    b.HasKey("CategoriesId", "GamesId");

                    b.HasIndex("GamesId");

                    b.ToTable("CategoryGame");

                    b.HasData(
                        new
                        {
                            CategoriesId = 1,
                            GamesId = 1
                        },
                        new
                        {
                            CategoriesId = 2,
                            GamesId = 1
                        },
                        new
                        {
                            CategoriesId = 3,
                            GamesId = 1
                        },
                        new
                        {
                            CategoriesId = 1,
                            GamesId = 2
                        },
                        new
                        {
                            CategoriesId = 3,
                            GamesId = 2
                        },
                        new
                        {
                            CategoriesId = 2,
                            GamesId = 2
                        },
                        new
                        {
                            CategoriesId = 1,
                            GamesId = 3
                        },
                        new
                        {
                            CategoriesId = 2,
                            GamesId = 3
                        });
                });

            modelBuilder.Entity("Pri.Ca.Core.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Sports"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Action"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Kids"
                        });
                });

            modelBuilder.Entity("Pri.Ca.Core.Entities.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Games");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Fifa2000"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Wolfenstein"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Minecraft"
                        });
                });

            modelBuilder.Entity("CategoryGame", b =>
                {
                    b.HasOne("Pri.Ca.Core.Entities.Category", null)
                        .WithMany()
                        .HasForeignKey("CategoriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Pri.Ca.Core.Entities.Game", null)
                        .WithMany()
                        .HasForeignKey("GamesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}