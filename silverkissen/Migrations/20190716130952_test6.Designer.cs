﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using silverkissen.Models;

namespace silverkissen.Migrations
{
    [DbContext(typeof(SilverkissenContext))]
    [Migration("20190716130952_test6")]
    partial class test6
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("silverkissen.Models.Cat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age");

                    b.Property<DateTime>("BirthDate");

                    b.Property<string>("Breed");

                    b.Property<int>("CatLitterId");

                    b.Property<bool>("Chipped");

                    b.Property<string>("Color");

                    b.Property<string>("Name");

                    b.Property<string>("Notes");

                    b.Property<bool>("Parent");

                    b.Property<bool>("Pedigree");

                    b.Property<string>("Sex");

                    b.Property<bool>("Vaccinated");

                    b.HasKey("Id");

                    b.HasIndex("CatLitterId");

                    b.ToTable("Cats");
                });

            modelBuilder.Entity("silverkissen.Models.CatLitter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AmountOfKids");

                    b.Property<DateTime>("BirthDate");

                    b.Property<bool>("Chipped");

                    b.Property<string>("Notes");

                    b.Property<bool>("Pedigree");

                    b.Property<string>("PedigreeName");

                    b.Property<DateTime>("ReadyDate");

                    b.Property<bool>("SVERAK");

                    b.Property<int>("Status");

                    b.Property<bool>("Vaccinated");

                    b.HasKey("Id");

                    b.ToTable("CatLitters");
                });

            modelBuilder.Entity("silverkissen.Models.CatLitter_Parent", b =>
                {
                    b.Property<int>("CatId");

                    b.Property<int>("CatLitterId");

                    b.HasKey("CatId", "CatLitterId");

                    b.HasIndex("CatLitterId");

                    b.ToTable("CatLitter_Parent");
                });

            modelBuilder.Entity("silverkissen.Models.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CatId");

                    b.Property<string>("Filename");

                    b.Property<string>("Filetype");

                    b.Property<string>("Value");

                    b.HasKey("Id");

                    b.HasIndex("CatId");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("silverkissen.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Password");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("silverkissen.Models.Cat", b =>
                {
                    b.HasOne("silverkissen.Models.CatLitter")
                        .WithMany("Kittens")
                        .HasForeignKey("CatLitterId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("silverkissen.Models.CatLitter_Parent", b =>
                {
                    b.HasOne("silverkissen.Models.CatLitter")
                        .WithMany("Parents")
                        .HasForeignKey("CatLitterId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("silverkissen.Models.Image", b =>
                {
                    b.HasOne("silverkissen.Models.Cat")
                        .WithMany("Images")
                        .HasForeignKey("CatId");
                });
#pragma warning restore 612, 618
        }
    }
}
