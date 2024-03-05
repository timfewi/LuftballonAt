using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LuftballonAt.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddCartTokenToShoppingCartEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TimeStamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<long>(type: "bigint", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    RoleId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    ArticleNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    InStock = table.Column<bool>(type: "bit", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TimeStamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductColors",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ColorHex = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TimeStamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductColors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductColors_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductImage",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TimeStamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductImage_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCarts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppUserId = table.Column<long>(type: "bigint", nullable: true),
                    ProductId = table.Column<long>(type: "bigint", nullable: true),
                    CartToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TimeStamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCarts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingCarts_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ShoppingCarts_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "CreatedDate", "Description", "ImageUrl", "LastModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1L, new DateTime(2024, 3, 1, 15, 2, 9, 117, DateTimeKind.Local).AddTicks(5222), "Luftballons in verschiedenen Farben und Größen. Perfekt für jede Party oder Feier.", "https://dummyimage.com/600x400/000/fff&text=Kategorie+1", null, "Standard" },
                    { 2L, new DateTime(2024, 3, 1, 15, 2, 9, 117, DateTimeKind.Local).AddTicks(5269), "Romantische und elegante Luftballons, ideal für Hochzeiten, Verlobungen und Jahrestage. Designs umfassen Herzen, Paare und liebevolle Botschaften.", "https://dummyimage.com/600x400/000/FF5733&text=Kategorie+2", null, "Liebe & Hochzeit" },
                    { 3L, new DateTime(2024, 3, 1, 15, 2, 9, 117, DateTimeKind.Local).AddTicks(5272), "Alphabet-Luftballons in verschiedenen Farben und Größen. Perfekt, um Namen, Initialen oder besondere Nachrichten zu kreieren.", "https://dummyimage.com/600x400/000/DAF7A6&text=Kategorie+3", null, "Buchstaben" },
                    { 4L, new DateTime(2024, 3, 1, 15, 2, 9, 117, DateTimeKind.Local).AddTicks(5273), "Zahlen-Luftballons für Geburtstage, Jubiläen oder besondere Jahrestage. Verfügbar in verschiedenen Größen und Farben, um jedes Alter zu feiern.", "https://dummyimage.com/600x400/000/C70039&text=Kategorie+4", null, "Zahlen" },
                    { 5L, new DateTime(2024, 3, 1, 15, 2, 9, 117, DateTimeKind.Local).AddTicks(5275), "Bunte und lebendige Luftballons für jede Party oder Feier. Vielfältige Formen und Farben, geeignet für Themenpartys und festliche Anlässe.", "https://dummyimage.com/600x400/000/FFC300&text=Kategorie+5", null, "Party" },
                    { 6L, new DateTime(2024, 3, 1, 15, 2, 9, 117, DateTimeKind.Local).AddTicks(5277), "Spezielle Geburtstagsluftballons mit Altersangaben, Glückwünschen und lustigen Motiven. Perfekt, um den besonderen Tag zu feiern.", "https://dummyimage.com/600x400/000/581845&text=Kategorie+6", null, "Geburtstag" },
                    { 7L, new DateTime(2024, 3, 1, 15, 2, 9, 117, DateTimeKind.Local).AddTicks(5279), "Sanfte und niedliche Luftballons für Babypartys, Geburten und Taufen. Motive umfassen Babyschuhe, Schnuller und Babytiere.", "https://dummyimage.com/600x400/000/3498DB&text=Kategorie+7", null, "Baby" },
                    { 8L, new DateTime(2024, 3, 1, 15, 2, 9, 117, DateTimeKind.Local).AddTicks(5280), "Luftballons passend zu jeder Jahreszeit – von blühenden Blumen im Frühling bis zu Schneeflocken im Winter. Ideal für saisonale Veranstaltungen und Dekorationen.", "https://dummyimage.com/600x400/000/2ECC71&text=Kategorie+8", null, "Jahreszeiten" },
                    { 9L, new DateTime(2024, 3, 1, 15, 2, 9, 117, DateTimeKind.Local).AddTicks(5282), "Tierluftballons in Form von Haustieren, wilden Tieren und Meerestieren. Spaß für Kinderpartys und Tierliebhaber jeder Altersgruppe.", "https://dummyimage.com/600x400/000/F1C40F&text=Kategorie+9", null, "Tiere" },
                    { 10L, new DateTime(2024, 3, 1, 15, 2, 9, 117, DateTimeKind.Local).AddTicks(5284), "Lebensmittel- und Getränkemotive, von Früchten bis zu Cocktails. Tolle Ergänzung für Themenpartys und kulinarische Events.", "https://dummyimage.com/600x400/000/E74C3C&text=Kategorie+10", null, "Essen & Trinken" },
                    { 11L, new DateTime(2024, 3, 1, 15, 2, 9, 117, DateTimeKind.Local).AddTicks(5285), "Beliebte Charaktere aus Filmen, Fernsehshows und Comics. Ideal für Themenpartys und Fans von spezifischen Genres oder Figuren.", "https://dummyimage.com/600x400/000/E91E63&text=Kategorie+11", null, "Charaktere" },
                    { 12L, new DateTime(2024, 3, 1, 15, 2, 9, 117, DateTimeKind.Local).AddTicks(5287), "Luftballons in Form von Autos, Flugzeugen, Schiffen und mehr. Perfekt für kleine Entdecker und Themenpartys mit Fahrzeugmotiven.", "https://dummyimage.com/600x400/000/9C27B0&text=Kategorie+12", null, "Fahrzeuge" }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "ArticleNumber", "CategoryId", "CreatedDate", "Description", "ImageUrl", "InStock", "LastModifiedDate", "Name", "Price", "Stock" },
                values: new object[,]
                {
                    { 1L, "LB-001", 1L, new DateTime(2024, 3, 1, 15, 2, 9, 117, DateTimeKind.Local).AddTicks(5432), "Standard Luftballon in verschiedenen Farben und Größen.", "https://dummyimage.com/600x400/000/fff&text=Luftballon+1", true, null, "Standard Luftballon", 1.99, 100 },
                    { 2L, "LB-002", 2L, new DateTime(2024, 3, 1, 15, 2, 9, 117, DateTimeKind.Local).AddTicks(5436), "Romantischer Herzluftballon in verschiedenen Farben und Größen.", "https://dummyimage.com/600x400/001f3f/ffffff&text=Luftballon+2", true, null, "Herz Luftballon", 2.9900000000000002, 100 },
                    { 3L, "LB-003", 3L, new DateTime(2024, 3, 1, 15, 2, 9, 117, DateTimeKind.Local).AddTicks(5439), "Alphabet-Luftballon in verschiedenen Farben und Größen.", "https://dummyimage.com/600x400/0074D9/ffffff&text=Luftballon+3", true, null, "Buchstaben Luftballon", 3.9900000000000002, 100 },
                    { 4L, "LB-004", 4L, new DateTime(2024, 3, 1, 15, 2, 9, 117, DateTimeKind.Local).AddTicks(5442), "Zahlen-Luftballon in verschiedenen Farben und Größen.", "https://dummyimage.com/600x400/7FDBFF/000000&text=Luftballon+4", true, null, "Zahlen Luftballon", 4.9900000000000002, 100 },
                    { 5L, "LB-005", 5L, new DateTime(2024, 3, 1, 15, 2, 9, 117, DateTimeKind.Local).AddTicks(5445), "Bunter und lebendiger Luftballon für jede Party oder Feier.", "https://dummyimage.com/600x400/39CCCC/000000&text=Luftballon+5", true, null, "Party Luftballon", 5.9900000000000002, 100 },
                    { 6L, "LB-006", 6L, new DateTime(2024, 3, 1, 15, 2, 9, 117, DateTimeKind.Local).AddTicks(5447), "Spezieller Geburtstagsluftballon mit Altersangabe.", "https://dummyimage.com/600x400/3D9970/ffffff&text=Luftballon+6", true, null, "Geburtstags Luftballon", 6.9900000000000002, 100 },
                    { 7L, "LB-007", 7L, new DateTime(2024, 3, 1, 15, 2, 9, 117, DateTimeKind.Local).AddTicks(5449), "Sanfter und niedlicher Luftballon für Babypartys.", "https://dummyimage.com/600x400/2ECC40/ffffff&text=Luftballon+7", true, null, "Baby Luftballon", 7.9900000000000002, 100 },
                    { 8L, "LB-008", 8L, new DateTime(2024, 3, 1, 15, 2, 9, 117, DateTimeKind.Local).AddTicks(5451), "Eleganter und stilvoller Luftballon für besondere Anlässe.", "https://dummyimage.com/600x400/FFDC00/000000&text=Luftballon+8", true, null, "Fancy Luftballon", 8.9900000000000002, 100 },
                    { 9L, "LB-009", 9L, new DateTime(2024, 3, 1, 15, 2, 9, 117, DateTimeKind.Local).AddTicks(5453), "Tierformiger Luftballon für tierische Themenpartys.", "https://dummyimage.com/600x400/FF851B/ffffff&text=Luftballon+9", true, null, "Tier Luftballon", 9.9900000000000002, 100 },
                    { 10L, "LB-010", 10L, new DateTime(2024, 3, 1, 15, 2, 9, 117, DateTimeKind.Local).AddTicks(5455), "Luftballon mit verschiedenen Emoji-Designs.", "https://dummyimage.com/600x400/FF4136/ffffff&text=Luftballon+10", true, null, "Emoji Luftballon", 10.99, 100 },
                    { 11L, "LB-011", 11L, new DateTime(2024, 3, 1, 15, 2, 9, 117, DateTimeKind.Local).AddTicks(5457), "Glitzernder Luftballon für glanzvolle Events.", "https://dummyimage.com/600x400/85144b/ffffff&text=Luftballon+11", true, null, "Glitzer Luftballon", 11.99, 100 },
                    { 12L, "LB-012", 12L, new DateTime(2024, 3, 1, 15, 2, 9, 117, DateTimeKind.Local).AddTicks(5459), "Luftballon mit Sportmotiven für Sportveranstaltungen.", "https://dummyimage.com/600x400/F012BE/ffffff&text=Luftballon+12", true, null, "Sport Luftballon", 12.99, 100 },
                    { 13L, "LB-013", 1L, new DateTime(2024, 3, 1, 15, 2, 9, 117, DateTimeKind.Local).AddTicks(5461), "Luftballon mit Musikinstrumenten-Designs für musikalische Veranstaltungen.", "https://dummyimage.com/600x400/B10DC9/ffffff&text=Luftballon+13", true, null, "Musik Luftballon", 13.99, 100 },
                    { 14L, "LB-014", 2L, new DateTime(2024, 3, 1, 15, 2, 9, 117, DateTimeKind.Local).AddTicks(5463), "Luftballon mit Filmthemen für Filmpremieren und -partys.", "https://dummyimage.com/600x400/AAAAAA/ffffff&text=Luftballon+14", true, null, "Film Luftballon", 14.99, 100 },
                    { 15L, "LB-015", 3L, new DateTime(2024, 3, 1, 15, 2, 9, 117, DateTimeKind.Local).AddTicks(5465), "Luftballon mit wissenschaftlichen Motiven für Wissenschaftsveranstaltungen.", "https://dummyimage.com/600x400/111111/ffffff&text=Luftballon+15", true, null, "Science Luftballon", 15.99, 100 },
                    { 16L, "LB-016", 4L, new DateTime(2024, 3, 1, 15, 2, 9, 117, DateTimeKind.Local).AddTicks(5467), "Luftballon mit fantasievollen Designs für Fantasy-Events.", "https://dummyimage.com/600x400/01FF70/000000&text=Luftballon+16", true, null, "Fantasy Luftballon", 16.989999999999998, 100 },
                    { 17L, "LB-017", 5L, new DateTime(2024, 3, 1, 15, 2, 9, 117, DateTimeKind.Local).AddTicks(5469), "Luftballon mit Feiertagsmotiven für festliche Anlässe.", "https://dummyimage.com/600x400/FFD700/000000&text=Luftballon+17", true, null, "Holiday Luftballon", 17.989999999999998, 100 },
                    { 18L, "LB-018", 6L, new DateTime(2024, 3, 1, 15, 2, 9, 117, DateTimeKind.Local).AddTicks(5472), "Luftballon mit Naturmotiven für Naturliebhaber.", "https://dummyimage.com/600x400/007FFF/ffffff&text=Luftballon+18", true, null, "Nature Luftballon", 18.989999999999998, 100 },
                    { 19L, "LB-019", 7L, new DateTime(2024, 3, 1, 15, 2, 9, 117, DateTimeKind.Local).AddTicks(5474), "Luftballon mit Weltraumdesigns für Raumfahrtfans.", "https://dummyimage.com/600x400/700B97/ffffff&text=Luftballon+19", true, null, "Space Luftballon", 19.989999999999998, 100 },
                    { 20L, "LB-020", 8L, new DateTime(2024, 3, 1, 15, 2, 9, 117, DateTimeKind.Local).AddTicks(5476), "Luftballon mit modischen Designs für Fashion-Events.", "https://dummyimage.com/600x400/0E0B16/ffffff&text=Luftballon+20", true, null, "Fashion Luftballon", 20.989999999999998, 100 },
                    { 21L, "LB-021", 9L, new DateTime(2024, 3, 1, 15, 2, 9, 117, DateTimeKind.Local).AddTicks(5478), "Luftballon im Vintage-Stil für Retro-Partys.", "https://dummyimage.com/600x400/FF0000/ffffff&text=Luftballon+21", true, null, "Vintage Luftballon", 21.989999999999998, 100 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryId",
                table: "Product",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductColors_ProductId",
                table: "ProductColors",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImage_ProductId",
                table: "ProductImage",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarts_AppUserId",
                table: "ShoppingCarts",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarts_ProductId",
                table: "ShoppingCarts",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "ProductColors");

            migrationBuilder.DropTable(
                name: "ProductImage");

            migrationBuilder.DropTable(
                name: "ShoppingCarts");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
