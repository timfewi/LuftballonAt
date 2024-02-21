﻿// <auto-generated />
using System;
using LuftballonAt.Web.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LuftballonAt.Web.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240221194853_SeedingDummyData")]
    partial class SeedingDummyData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LuftballonAt.Models.Entities.ProductEntities.Category", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("TimeStamp")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.ToTable("Category");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            CreatedDate = new DateTime(2024, 2, 21, 20, 48, 52, 235, DateTimeKind.Local).AddTicks(5659),
                            Description = "Luftballons in verschiedenen Farben und Größen. Perfekt für jede Party oder Feier.",
                            ImageUrl = "https://dummyimage.com/600x400/000/fff&text=Kategorie+1",
                            Name = "Standard"
                        },
                        new
                        {
                            Id = 2L,
                            CreatedDate = new DateTime(2024, 2, 21, 20, 48, 52, 235, DateTimeKind.Local).AddTicks(5706),
                            Description = "Romantische und elegante Luftballons, ideal für Hochzeiten, Verlobungen und Jahrestage. Designs umfassen Herzen, Paare und liebevolle Botschaften.",
                            ImageUrl = "https://dummyimage.com/600x400/000/FF5733&text=Kategorie+2",
                            Name = "Liebe & Hochzeit"
                        },
                        new
                        {
                            Id = 3L,
                            CreatedDate = new DateTime(2024, 2, 21, 20, 48, 52, 235, DateTimeKind.Local).AddTicks(5709),
                            Description = "Alphabet-Luftballons in verschiedenen Farben und Größen. Perfekt, um Namen, Initialen oder besondere Nachrichten zu kreieren.",
                            ImageUrl = "https://dummyimage.com/600x400/000/DAF7A6&text=Kategorie+3",
                            Name = "Buchstaben"
                        },
                        new
                        {
                            Id = 4L,
                            CreatedDate = new DateTime(2024, 2, 21, 20, 48, 52, 235, DateTimeKind.Local).AddTicks(5711),
                            Description = "Zahlen-Luftballons für Geburtstage, Jubiläen oder besondere Jahrestage. Verfügbar in verschiedenen Größen und Farben, um jedes Alter zu feiern.",
                            ImageUrl = "https://dummyimage.com/600x400/000/C70039&text=Kategorie+4",
                            Name = "Zahlen"
                        },
                        new
                        {
                            Id = 5L,
                            CreatedDate = new DateTime(2024, 2, 21, 20, 48, 52, 235, DateTimeKind.Local).AddTicks(5712),
                            Description = "Bunte und lebendige Luftballons für jede Party oder Feier. Vielfältige Formen und Farben, geeignet für Themenpartys und festliche Anlässe.",
                            ImageUrl = "https://dummyimage.com/600x400/000/FFC300&text=Kategorie+5",
                            Name = "Party"
                        },
                        new
                        {
                            Id = 6L,
                            CreatedDate = new DateTime(2024, 2, 21, 20, 48, 52, 235, DateTimeKind.Local).AddTicks(5714),
                            Description = "Spezielle Geburtstagsluftballons mit Altersangaben, Glückwünschen und lustigen Motiven. Perfekt, um den besonderen Tag zu feiern.",
                            ImageUrl = "https://dummyimage.com/600x400/000/581845&text=Kategorie+6",
                            Name = "Geburtstag"
                        },
                        new
                        {
                            Id = 7L,
                            CreatedDate = new DateTime(2024, 2, 21, 20, 48, 52, 235, DateTimeKind.Local).AddTicks(5716),
                            Description = "Sanfte und niedliche Luftballons für Babypartys, Geburten und Taufen. Motive umfassen Babyschuhe, Schnuller und Babytiere.",
                            ImageUrl = "https://dummyimage.com/600x400/000/3498DB&text=Kategorie+7",
                            Name = "Baby"
                        },
                        new
                        {
                            Id = 8L,
                            CreatedDate = new DateTime(2024, 2, 21, 20, 48, 52, 235, DateTimeKind.Local).AddTicks(5718),
                            Description = "Luftballons passend zu jeder Jahreszeit – von blühenden Blumen im Frühling bis zu Schneeflocken im Winter. Ideal für saisonale Veranstaltungen und Dekorationen.",
                            ImageUrl = "https://dummyimage.com/600x400/000/2ECC71&text=Kategorie+8",
                            Name = "Jahreszeiten"
                        },
                        new
                        {
                            Id = 9L,
                            CreatedDate = new DateTime(2024, 2, 21, 20, 48, 52, 235, DateTimeKind.Local).AddTicks(5719),
                            Description = "Tierluftballons in Form von Haustieren, wilden Tieren und Meerestieren. Spaß für Kinderpartys und Tierliebhaber jeder Altersgruppe.",
                            ImageUrl = "https://dummyimage.com/600x400/000/F1C40F&text=Kategorie+9",
                            Name = "Tiere"
                        },
                        new
                        {
                            Id = 10L,
                            CreatedDate = new DateTime(2024, 2, 21, 20, 48, 52, 235, DateTimeKind.Local).AddTicks(5721),
                            Description = "Lebensmittel- und Getränkemotive, von Früchten bis zu Cocktails. Tolle Ergänzung für Themenpartys und kulinarische Events.",
                            ImageUrl = "https://dummyimage.com/600x400/000/E74C3C&text=Kategorie+10",
                            Name = "Essen & Trinken"
                        },
                        new
                        {
                            Id = 11L,
                            CreatedDate = new DateTime(2024, 2, 21, 20, 48, 52, 235, DateTimeKind.Local).AddTicks(5723),
                            Description = "Beliebte Charaktere aus Filmen, Fernsehshows und Comics. Ideal für Themenpartys und Fans von spezifischen Genres oder Figuren.",
                            ImageUrl = "https://dummyimage.com/600x400/000/E91E63&text=Kategorie+11",
                            Name = "Charaktere"
                        },
                        new
                        {
                            Id = 12L,
                            CreatedDate = new DateTime(2024, 2, 21, 20, 48, 52, 235, DateTimeKind.Local).AddTicks(5725),
                            Description = "Luftballons in Form von Autos, Flugzeugen, Schiffen und mehr. Perfekt für kleine Entdecker und Themenpartys mit Fahrzeugmotiven.",
                            ImageUrl = "https://dummyimage.com/600x400/000/9C27B0&text=Kategorie+12",
                            Name = "Fahrzeuge"
                        });
                });

            modelBuilder.Entity("LuftballonAt.Models.Entities.ProductEntities.Product", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("ArticleNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("CategoryId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("InStock")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.Property<byte[]>("TimeStamp")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Product");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            ArticleNumber = "LB-001",
                            CategoryId = 1L,
                            CreatedDate = new DateTime(2024, 2, 21, 20, 48, 52, 235, DateTimeKind.Local).AddTicks(5856),
                            Description = "Standard Luftballon in verschiedenen Farben und Größen.",
                            ImageUrl = "https://dummyimage.com/600x400/000/fff&text=Luftballon+1",
                            InStock = true,
                            Name = "Standard Luftballon",
                            Price = 1.99,
                            Stock = 100
                        },
                        new
                        {
                            Id = 2L,
                            ArticleNumber = "LB-002",
                            CategoryId = 2L,
                            CreatedDate = new DateTime(2024, 2, 21, 20, 48, 52, 235, DateTimeKind.Local).AddTicks(5860),
                            Description = "Romantischer Herzluftballon in verschiedenen Farben und Größen.",
                            ImageUrl = "https://dummyimage.com/600x400/001f3f/ffffff&text=Luftballon+2",
                            InStock = true,
                            Name = "Herz Luftballon",
                            Price = 2.9900000000000002,
                            Stock = 100
                        },
                        new
                        {
                            Id = 3L,
                            ArticleNumber = "LB-003",
                            CategoryId = 3L,
                            CreatedDate = new DateTime(2024, 2, 21, 20, 48, 52, 235, DateTimeKind.Local).AddTicks(5863),
                            Description = "Alphabet-Luftballon in verschiedenen Farben und Größen.",
                            ImageUrl = "https://dummyimage.com/600x400/0074D9/ffffff&text=Luftballon+3",
                            InStock = true,
                            Name = "Buchstaben Luftballon",
                            Price = 3.9900000000000002,
                            Stock = 100
                        },
                        new
                        {
                            Id = 4L,
                            ArticleNumber = "LB-004",
                            CategoryId = 4L,
                            CreatedDate = new DateTime(2024, 2, 21, 20, 48, 52, 235, DateTimeKind.Local).AddTicks(5865),
                            Description = "Zahlen-Luftballon in verschiedenen Farben und Größen.",
                            ImageUrl = "https://dummyimage.com/600x400/7FDBFF/000000&text=Luftballon+4",
                            InStock = true,
                            Name = "Zahlen Luftballon",
                            Price = 4.9900000000000002,
                            Stock = 100
                        },
                        new
                        {
                            Id = 5L,
                            ArticleNumber = "LB-005",
                            CategoryId = 5L,
                            CreatedDate = new DateTime(2024, 2, 21, 20, 48, 52, 235, DateTimeKind.Local).AddTicks(5867),
                            Description = "Bunter und lebendiger Luftballon für jede Party oder Feier.",
                            ImageUrl = "https://dummyimage.com/600x400/39CCCC/000000&text=Luftballon+5",
                            InStock = true,
                            Name = "Party Luftballon",
                            Price = 5.9900000000000002,
                            Stock = 100
                        },
                        new
                        {
                            Id = 6L,
                            ArticleNumber = "LB-006",
                            CategoryId = 6L,
                            CreatedDate = new DateTime(2024, 2, 21, 20, 48, 52, 235, DateTimeKind.Local).AddTicks(5872),
                            Description = "Spezieller Geburtstagsluftballon mit Altersangabe.",
                            ImageUrl = "https://dummyimage.com/600x400/3D9970/ffffff&text=Luftballon+6",
                            InStock = true,
                            Name = "Geburtstags Luftballon",
                            Price = 6.9900000000000002,
                            Stock = 100
                        },
                        new
                        {
                            Id = 7L,
                            ArticleNumber = "LB-007",
                            CategoryId = 7L,
                            CreatedDate = new DateTime(2024, 2, 21, 20, 48, 52, 235, DateTimeKind.Local).AddTicks(5874),
                            Description = "Sanfter und niedlicher Luftballon für Babypartys.",
                            ImageUrl = "https://dummyimage.com/600x400/2ECC40/ffffff&text=Luftballon+7",
                            InStock = true,
                            Name = "Baby Luftballon",
                            Price = 7.9900000000000002,
                            Stock = 100
                        },
                        new
                        {
                            Id = 8L,
                            ArticleNumber = "LB-008",
                            CategoryId = 8L,
                            CreatedDate = new DateTime(2024, 2, 21, 20, 48, 52, 235, DateTimeKind.Local).AddTicks(5877),
                            Description = "Eleganter und stilvoller Luftballon für besondere Anlässe.",
                            ImageUrl = "https://dummyimage.com/600x400/FFDC00/000000&text=Luftballon+8",
                            InStock = true,
                            Name = "Fancy Luftballon",
                            Price = 8.9900000000000002,
                            Stock = 100
                        },
                        new
                        {
                            Id = 9L,
                            ArticleNumber = "LB-009",
                            CategoryId = 9L,
                            CreatedDate = new DateTime(2024, 2, 21, 20, 48, 52, 235, DateTimeKind.Local).AddTicks(5879),
                            Description = "Tierformiger Luftballon für tierische Themenpartys.",
                            ImageUrl = "https://dummyimage.com/600x400/FF851B/ffffff&text=Luftballon+9",
                            InStock = true,
                            Name = "Tier Luftballon",
                            Price = 9.9900000000000002,
                            Stock = 100
                        },
                        new
                        {
                            Id = 10L,
                            ArticleNumber = "LB-010",
                            CategoryId = 10L,
                            CreatedDate = new DateTime(2024, 2, 21, 20, 48, 52, 235, DateTimeKind.Local).AddTicks(5881),
                            Description = "Luftballon mit verschiedenen Emoji-Designs.",
                            ImageUrl = "https://dummyimage.com/600x400/FF4136/ffffff&text=Luftballon+10",
                            InStock = true,
                            Name = "Emoji Luftballon",
                            Price = 10.99,
                            Stock = 100
                        },
                        new
                        {
                            Id = 11L,
                            ArticleNumber = "LB-011",
                            CategoryId = 11L,
                            CreatedDate = new DateTime(2024, 2, 21, 20, 48, 52, 235, DateTimeKind.Local).AddTicks(5883),
                            Description = "Glitzernder Luftballon für glanzvolle Events.",
                            ImageUrl = "https://dummyimage.com/600x400/85144b/ffffff&text=Luftballon+11",
                            InStock = true,
                            Name = "Glitzer Luftballon",
                            Price = 11.99,
                            Stock = 100
                        },
                        new
                        {
                            Id = 12L,
                            ArticleNumber = "LB-012",
                            CategoryId = 12L,
                            CreatedDate = new DateTime(2024, 2, 21, 20, 48, 52, 235, DateTimeKind.Local).AddTicks(5885),
                            Description = "Luftballon mit Sportmotiven für Sportveranstaltungen.",
                            ImageUrl = "https://dummyimage.com/600x400/F012BE/ffffff&text=Luftballon+12",
                            InStock = true,
                            Name = "Sport Luftballon",
                            Price = 12.99,
                            Stock = 100
                        },
                        new
                        {
                            Id = 13L,
                            ArticleNumber = "LB-013",
                            CategoryId = 1L,
                            CreatedDate = new DateTime(2024, 2, 21, 20, 48, 52, 235, DateTimeKind.Local).AddTicks(5887),
                            Description = "Luftballon mit Musikinstrumenten-Designs für musikalische Veranstaltungen.",
                            ImageUrl = "https://dummyimage.com/600x400/B10DC9/ffffff&text=Luftballon+13",
                            InStock = true,
                            Name = "Musik Luftballon",
                            Price = 13.99,
                            Stock = 100
                        },
                        new
                        {
                            Id = 14L,
                            ArticleNumber = "LB-014",
                            CategoryId = 2L,
                            CreatedDate = new DateTime(2024, 2, 21, 20, 48, 52, 235, DateTimeKind.Local).AddTicks(5889),
                            Description = "Luftballon mit Filmthemen für Filmpremieren und -partys.",
                            ImageUrl = "https://dummyimage.com/600x400/AAAAAA/ffffff&text=Luftballon+14",
                            InStock = true,
                            Name = "Film Luftballon",
                            Price = 14.99,
                            Stock = 100
                        },
                        new
                        {
                            Id = 15L,
                            ArticleNumber = "LB-015",
                            CategoryId = 3L,
                            CreatedDate = new DateTime(2024, 2, 21, 20, 48, 52, 235, DateTimeKind.Local).AddTicks(5891),
                            Description = "Luftballon mit wissenschaftlichen Motiven für Wissenschaftsveranstaltungen.",
                            ImageUrl = "https://dummyimage.com/600x400/111111/ffffff&text=Luftballon+15",
                            InStock = true,
                            Name = "Science Luftballon",
                            Price = 15.99,
                            Stock = 100
                        },
                        new
                        {
                            Id = 16L,
                            ArticleNumber = "LB-016",
                            CategoryId = 4L,
                            CreatedDate = new DateTime(2024, 2, 21, 20, 48, 52, 235, DateTimeKind.Local).AddTicks(5895),
                            Description = "Luftballon mit fantasievollen Designs für Fantasy-Events.",
                            ImageUrl = "https://dummyimage.com/600x400/01FF70/000000&text=Luftballon+16",
                            InStock = true,
                            Name = "Fantasy Luftballon",
                            Price = 16.989999999999998,
                            Stock = 100
                        },
                        new
                        {
                            Id = 17L,
                            ArticleNumber = "LB-017",
                            CategoryId = 5L,
                            CreatedDate = new DateTime(2024, 2, 21, 20, 48, 52, 235, DateTimeKind.Local).AddTicks(5897),
                            Description = "Luftballon mit Feiertagsmotiven für festliche Anlässe.",
                            ImageUrl = "https://dummyimage.com/600x400/FFD700/000000&text=Luftballon+17",
                            InStock = true,
                            Name = "Holiday Luftballon",
                            Price = 17.989999999999998,
                            Stock = 100
                        },
                        new
                        {
                            Id = 18L,
                            ArticleNumber = "LB-018",
                            CategoryId = 6L,
                            CreatedDate = new DateTime(2024, 2, 21, 20, 48, 52, 235, DateTimeKind.Local).AddTicks(5899),
                            Description = "Luftballon mit Naturmotiven für Naturliebhaber.",
                            ImageUrl = "https://dummyimage.com/600x400/007FFF/ffffff&text=Luftballon+18",
                            InStock = true,
                            Name = "Nature Luftballon",
                            Price = 18.989999999999998,
                            Stock = 100
                        },
                        new
                        {
                            Id = 19L,
                            ArticleNumber = "LB-019",
                            CategoryId = 7L,
                            CreatedDate = new DateTime(2024, 2, 21, 20, 48, 52, 235, DateTimeKind.Local).AddTicks(5901),
                            Description = "Luftballon mit Weltraumdesigns für Raumfahrtfans.",
                            ImageUrl = "https://dummyimage.com/600x400/700B97/ffffff&text=Luftballon+19",
                            InStock = true,
                            Name = "Space Luftballon",
                            Price = 19.989999999999998,
                            Stock = 100
                        },
                        new
                        {
                            Id = 20L,
                            ArticleNumber = "LB-020",
                            CategoryId = 8L,
                            CreatedDate = new DateTime(2024, 2, 21, 20, 48, 52, 235, DateTimeKind.Local).AddTicks(5904),
                            Description = "Luftballon mit modischen Designs für Fashion-Events.",
                            ImageUrl = "https://dummyimage.com/600x400/0E0B16/ffffff&text=Luftballon+20",
                            InStock = true,
                            Name = "Fashion Luftballon",
                            Price = 20.989999999999998,
                            Stock = 100
                        },
                        new
                        {
                            Id = 21L,
                            ArticleNumber = "LB-021",
                            CategoryId = 9L,
                            CreatedDate = new DateTime(2024, 2, 21, 20, 48, 52, 235, DateTimeKind.Local).AddTicks(5906),
                            Description = "Luftballon im Vintage-Stil für Retro-Partys.",
                            ImageUrl = "https://dummyimage.com/600x400/FF0000/ffffff&text=Luftballon+21",
                            InStock = true,
                            Name = "Vintage Luftballon",
                            Price = 21.989999999999998,
                            Stock = 100
                        });
                });

            modelBuilder.Entity("LuftballonAt.Models.Entities.UtilityEntities.ProductImage", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<long?>("ProductId")
                        .HasColumnType("bigint");

                    b.Property<byte[]>("TimeStamp")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductImage");
                });

            modelBuilder.Entity("LuftballonAt.Web.Areas.Identity.Data.AppUser", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<long>", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<long>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("RoleId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<long>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<long>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<long>", b =>
                {
                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<long>("RoleId")
                        .HasColumnType("bigint");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<long>", b =>
                {
                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("LuftballonAt.Models.Entities.ProductEntities.Product", b =>
                {
                    b.HasOne("LuftballonAt.Models.Entities.ProductEntities.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("LuftballonAt.Models.Entities.UtilityEntities.ProductImage", b =>
                {
                    b.HasOne("LuftballonAt.Models.Entities.ProductEntities.Product", "Product")
                        .WithMany("Images")
                        .HasForeignKey("ProductId");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<long>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<long>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<long>", b =>
                {
                    b.HasOne("LuftballonAt.Web.Areas.Identity.Data.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<long>", b =>
                {
                    b.HasOne("LuftballonAt.Web.Areas.Identity.Data.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<long>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<long>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LuftballonAt.Web.Areas.Identity.Data.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<long>", b =>
                {
                    b.HasOne("LuftballonAt.Web.Areas.Identity.Data.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LuftballonAt.Models.Entities.ProductEntities.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("LuftballonAt.Models.Entities.ProductEntities.Product", b =>
                {
                    b.Navigation("Images");
                });
#pragma warning restore 612, 618
        }
    }
}
