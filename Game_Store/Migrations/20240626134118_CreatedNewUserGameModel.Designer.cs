﻿// <auto-generated />
using System;
using Game_Store.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Game_Store.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240626134118_CreatedNewUserGameModel")]
    partial class CreatedNewUserGameModel
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Game_Store.Models.GameSummary", b =>
                {
                    b.Property<int>("GameId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GameId"));

                    b.Property<int?>("GenreID")
                        .HasColumnType("int");

                    b.Property<string>("Genres")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateOnly>("ReleaseDate")
                        .HasColumnType("date");

                    b.HasKey("GameId");

                    b.HasIndex("GenreID");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("Game_Store.Models.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Genre");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Fighting"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Roguelike"
                        },
                        new
                        {
                            Id = 3,
                            Name = "RPG"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Shooter"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Sports"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Role-playing"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Strategy"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Survival"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Puzzle"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Simulation"
                        },
                        new
                        {
                            Id = 11,
                            Name = "Racing"
                        },
                        new
                        {
                            Id = 12,
                            Name = "Sandbox"
                        },
                        new
                        {
                            Id = 13,
                            Name = "Kids and Family"
                        });
                });

            modelBuilder.Entity("Game_Store.Models.Transactions", b =>
                {
                    b.Property<int>("TransactionsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TransactionsId"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("GameId")
                        .HasColumnType("int");

                    b.Property<DateTime>("PurchaseDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("TransactionsId");

                    b.HasIndex("GameId");

                    b.HasIndex("UserId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("Game_Store.Models.UserGame", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("GameId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "GameId");

                    b.HasIndex("GameId");

                    b.ToTable("UserGames");
                });

            modelBuilder.Entity("Game_Store.Models.Users", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<decimal>("Balance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Game_Store.Models.GameSummary", b =>
                {
                    b.HasOne("Game_Store.Models.Genre", "Genre")
                        .WithMany("Games")
                        .HasForeignKey("GenreID");

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("Game_Store.Models.Transactions", b =>
                {
                    b.HasOne("Game_Store.Models.GameSummary", "Game")
                        .WithMany()
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Game_Store.Models.Users", "User")
                        .WithMany("Transactions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Game_Store.Models.UserGame", b =>
                {
                    b.HasOne("Game_Store.Models.GameSummary", "Game")
                        .WithMany("UserGames")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Game_Store.Models.Users", "User")
                        .WithMany("UserGames")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Game_Store.Models.GameSummary", b =>
                {
                    b.Navigation("UserGames");
                });

            modelBuilder.Entity("Game_Store.Models.Genre", b =>
                {
                    b.Navigation("Games");
                });

            modelBuilder.Entity("Game_Store.Models.Users", b =>
                {
                    b.Navigation("Transactions");

                    b.Navigation("UserGames");
                });
#pragma warning restore 612, 618
        }
    }
}
