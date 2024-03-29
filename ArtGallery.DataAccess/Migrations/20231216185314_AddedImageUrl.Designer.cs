﻿// <auto-generated />
using ArtGallery.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ArtGallery.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231216185314_AddedImageUrl")]
    partial class AddedImageUrl
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ArtGallery.Models.Art", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Artist")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Imageurl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("arts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Artist = "Kidus-Workneh",
                            CategoryId = 1,
                            Description = "A new form of art",
                            Imageurl = "",
                            Title = "Art1"
                        },
                        new
                        {
                            Id = 2,
                            Artist = "Abenezer-Daniel",
                            CategoryId = 2,
                            Description = "A new form of art",
                            Imageurl = "",
                            Title = "Art2"
                        },
                        new
                        {
                            Id = 3,
                            Artist = "Urael-Alemayehu",
                            CategoryId = 3,
                            Description = "A new form of art",
                            Imageurl = "",
                            Title = "Art3"
                        },
                        new
                        {
                            Id = 4,
                            Artist = "Ayesha-Abduljelil",
                            CategoryId = 2,
                            Description = "A new form of art",
                            Imageurl = "",
                            Title = "Art4"
                        },
                        new
                        {
                            Id = 5,
                            Artist = "Lucy",
                            CategoryId = 1,
                            Description = "A new form of art",
                            Imageurl = "",
                            Title = "Art5"
                        });
                });

            modelBuilder.Entity("ArtGallery.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Ethiopian-Art"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Photograph"
                        },
                        new
                        {
                            Id = 3,
                            Name = "3D-Art"
                        });
                });

            modelBuilder.Entity("ArtGallery.Models.Art", b =>
                {
                    b.HasOne("ArtGallery.Models.Category", "category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("category");
                });
#pragma warning restore 612, 618
        }
    }
}
