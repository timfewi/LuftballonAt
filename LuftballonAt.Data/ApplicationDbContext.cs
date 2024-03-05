

using LuftballonAt.Models.Entities.ProductEntities;
using LuftballonAt.Models.Entities.UtilityEntities;
using LuftballonAt.Web.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LuftballonAt.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser, IdentityRole<long>, long>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Identity Entities
        public DbSet<AppUser> AppUser { get; set; }


        // Product Entities
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductColor> ProductColors { get; set; }

        public DbSet<ShoppingCart> ShoppingCarts { get; set; }


        // Utility Entities
        public DbSet<ProductImage> Images { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);





            // Category Seed Data
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, ImageUrl = "https://dummyimage.com/600x400/000/fff&text=Kategorie+1", Name = "Standard", Description = "Luftballons in verschiedenen Farben und Größen. Perfekt für jede Party oder Feier." },
                new Category { Id = 2, ImageUrl = "https://dummyimage.com/600x400/000/FF5733&text=Kategorie+2", Name = "Liebe & Hochzeit", Description = "Romantische und elegante Luftballons, ideal für Hochzeiten, Verlobungen und Jahrestage. Designs umfassen Herzen, Paare und liebevolle Botschaften." },
                new Category { Id = 3, ImageUrl = "https://dummyimage.com/600x400/000/DAF7A6&text=Kategorie+3", Name = "Buchstaben", Description = "Alphabet-Luftballons in verschiedenen Farben und Größen. Perfekt, um Namen, Initialen oder besondere Nachrichten zu kreieren." },
                new Category { Id = 4, ImageUrl = "https://dummyimage.com/600x400/000/C70039&text=Kategorie+4", Name = "Zahlen", Description = "Zahlen-Luftballons für Geburtstage, Jubiläen oder besondere Jahrestage. Verfügbar in verschiedenen Größen und Farben, um jedes Alter zu feiern." },
                new Category { Id = 5, ImageUrl = "https://dummyimage.com/600x400/000/FFC300&text=Kategorie+5", Name = "Party", Description = "Bunte und lebendige Luftballons für jede Party oder Feier. Vielfältige Formen und Farben, geeignet für Themenpartys und festliche Anlässe." },
                new Category { Id = 6, ImageUrl = "https://dummyimage.com/600x400/000/581845&text=Kategorie+6", Name = "Geburtstag", Description = "Spezielle Geburtstagsluftballons mit Altersangaben, Glückwünschen und lustigen Motiven. Perfekt, um den besonderen Tag zu feiern." },
                new Category { Id = 7, ImageUrl = "https://dummyimage.com/600x400/000/3498DB&text=Kategorie+7", Name = "Baby", Description = "Sanfte und niedliche Luftballons für Babypartys, Geburten und Taufen. Motive umfassen Babyschuhe, Schnuller und Babytiere." },
                new Category { Id = 8, ImageUrl = "https://dummyimage.com/600x400/000/2ECC71&text=Kategorie+8", Name = "Jahreszeiten", Description = "Luftballons passend zu jeder Jahreszeit – von blühenden Blumen im Frühling bis zu Schneeflocken im Winter. Ideal für saisonale Veranstaltungen und Dekorationen." },
                new Category { Id = 9, ImageUrl = "https://dummyimage.com/600x400/000/F1C40F&text=Kategorie+9", Name = "Tiere", Description = "Tierluftballons in Form von Haustieren, wilden Tieren und Meerestieren. Spaß für Kinderpartys und Tierliebhaber jeder Altersgruppe." },
                new Category { Id = 10, ImageUrl = "https://dummyimage.com/600x400/000/E74C3C&text=Kategorie+10", Name = "Essen & Trinken", Description = "Lebensmittel- und Getränkemotive, von Früchten bis zu Cocktails. Tolle Ergänzung für Themenpartys und kulinarische Events." },
                new Category { Id = 11, ImageUrl = "https://dummyimage.com/600x400/000/E91E63&text=Kategorie+11", Name = "Charaktere", Description = "Beliebte Charaktere aus Filmen, Fernsehshows und Comics. Ideal für Themenpartys und Fans von spezifischen Genres oder Figuren." },
                new Category { Id = 12, ImageUrl = "https://dummyimage.com/600x400/000/9C27B0&text=Kategorie+12", Name = "Fahrzeuge", Description = "Luftballons in Form von Autos, Flugzeugen, Schiffen und mehr. Perfekt für kleine Entdecker und Themenpartys mit Fahrzeugmotiven." }
            );

            //Product Seed Data
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, ImageUrl = "https://dummyimage.com/600x400/000/fff&text=Luftballon+1", Name = "Standard Luftballon", Description = "Standard Luftballon in verschiedenen Farben und Größen.", Price = 1.99, ArticleNumber = "LB-001", Stock = 100, InStock = true, CategoryId = 1 },
                new Product { Id = 2, ImageUrl = "https://dummyimage.com/600x400/001f3f/ffffff&text=Luftballon+2", Name = "Herz Luftballon", Description = "Romantischer Herzluftballon in verschiedenen Farben und Größen.", Price = 2.99, ArticleNumber = "LB-002", Stock = 100, InStock = true, CategoryId = 2 },
                new Product { Id = 3, ImageUrl = "https://dummyimage.com/600x400/0074D9/ffffff&text=Luftballon+3", Name = "Buchstaben Luftballon", Description = "Alphabet-Luftballon in verschiedenen Farben und Größen.", Price = 3.99, ArticleNumber = "LB-003", Stock = 100, InStock = true, CategoryId = 3 },
                new Product { Id = 4, ImageUrl = "https://dummyimage.com/600x400/7FDBFF/000000&text=Luftballon+4", Name = "Zahlen Luftballon", Description = "Zahlen-Luftballon in verschiedenen Farben und Größen.", Price = 4.99, ArticleNumber = "LB-004", Stock = 100, InStock = true, CategoryId = 4 },
                new Product { Id = 5, ImageUrl = "https://dummyimage.com/600x400/39CCCC/000000&text=Luftballon+5", Name = "Party Luftballon", Description = "Bunter und lebendiger Luftballon für jede Party oder Feier.", Price = 5.99, ArticleNumber = "LB-005", Stock = 100, InStock = true, CategoryId = 5 },
                new Product { Id = 6, ImageUrl = "https://dummyimage.com/600x400/3D9970/ffffff&text=Luftballon+6", Name = "Geburtstags Luftballon", Description = "Spezieller Geburtstagsluftballon mit Altersangabe.", Price = 6.99, ArticleNumber = "LB-006", Stock = 100, InStock = true, CategoryId = 6 },
                new Product { Id = 7, ImageUrl = "https://dummyimage.com/600x400/2ECC40/ffffff&text=Luftballon+7", Name = "Baby Luftballon", Description = "Sanfter und niedlicher Luftballon für Babypartys.", Price = 7.99, ArticleNumber = "LB-007", Stock = 100, InStock = true, CategoryId = 7 },
                new Product { Id = 8, ImageUrl = "https://dummyimage.com/600x400/FFDC00/000000&text=Luftballon+8", Name = "Fancy Luftballon", Description = "Eleganter und stilvoller Luftballon für besondere Anlässe.", Price = 8.99, ArticleNumber = "LB-008", Stock = 100, InStock = true, CategoryId = 8 },
                new Product { Id = 9, ImageUrl = "https://dummyimage.com/600x400/FF851B/ffffff&text=Luftballon+9", Name = "Tier Luftballon", Description = "Tierformiger Luftballon für tierische Themenpartys.", Price = 9.99, ArticleNumber = "LB-009", Stock = 100, InStock = true, CategoryId = 9 },
                new Product { Id = 10, ImageUrl = "https://dummyimage.com/600x400/FF4136/ffffff&text=Luftballon+10", Name = "Emoji Luftballon", Description = "Luftballon mit verschiedenen Emoji-Designs.", Price = 10.99, ArticleNumber = "LB-010", Stock = 100, InStock = true, CategoryId = 10 },
                new Product { Id = 11, ImageUrl = "https://dummyimage.com/600x400/85144b/ffffff&text=Luftballon+11", Name = "Glitzer Luftballon", Description = "Glitzernder Luftballon für glanzvolle Events.", Price = 11.99, ArticleNumber = "LB-011", Stock = 100, InStock = true, CategoryId = 11 },
                new Product { Id = 12, ImageUrl = "https://dummyimage.com/600x400/F012BE/ffffff&text=Luftballon+12", Name = "Sport Luftballon", Description = "Luftballon mit Sportmotiven für Sportveranstaltungen.", Price = 12.99, ArticleNumber = "LB-012", Stock = 100, InStock = true, CategoryId = 12 },
                new Product { Id = 13, ImageUrl = "https://dummyimage.com/600x400/B10DC9/ffffff&text=Luftballon+13", Name = "Musik Luftballon", Description = "Luftballon mit Musikinstrumenten-Designs für musikalische Veranstaltungen.", Price = 13.99, ArticleNumber = "LB-013", Stock = 100, InStock = true, CategoryId = 1 },
                new Product { Id = 14, ImageUrl = "https://dummyimage.com/600x400/AAAAAA/ffffff&text=Luftballon+14", Name = "Film Luftballon", Description = "Luftballon mit Filmthemen für Filmpremieren und -partys.", Price = 14.99, ArticleNumber = "LB-014", Stock = 100, InStock = true, CategoryId = 2 },
                new Product { Id = 15, ImageUrl = "https://dummyimage.com/600x400/111111/ffffff&text=Luftballon+15", Name = "Science Luftballon", Description = "Luftballon mit wissenschaftlichen Motiven für Wissenschaftsveranstaltungen.", Price = 15.99, ArticleNumber = "LB-015", Stock = 100, InStock = true, CategoryId = 3 },
                new Product { Id = 16, ImageUrl = "https://dummyimage.com/600x400/01FF70/000000&text=Luftballon+16", Name = "Fantasy Luftballon", Description = "Luftballon mit fantasievollen Designs für Fantasy-Events.", Price = 16.99, ArticleNumber = "LB-016", Stock = 100, InStock = true, CategoryId = 4 },
                new Product { Id = 17, ImageUrl = "https://dummyimage.com/600x400/FFD700/000000&text=Luftballon+17", Name = "Holiday Luftballon", Description = "Luftballon mit Feiertagsmotiven für festliche Anlässe.", Price = 17.99, ArticleNumber = "LB-017", Stock = 100, InStock = true, CategoryId = 5 },
                new Product { Id = 18, ImageUrl = "https://dummyimage.com/600x400/007FFF/ffffff&text=Luftballon+18", Name = "Nature Luftballon", Description = "Luftballon mit Naturmotiven für Naturliebhaber.", Price = 18.99, ArticleNumber = "LB-018", Stock = 100, InStock = true, CategoryId = 6 },
                new Product { Id = 19, ImageUrl = "https://dummyimage.com/600x400/700B97/ffffff&text=Luftballon+19", Name = "Space Luftballon", Description = "Luftballon mit Weltraumdesigns für Raumfahrtfans.", Price = 19.99, ArticleNumber = "LB-019", Stock = 100, InStock = true, CategoryId = 7 },
                new Product { Id = 20, ImageUrl = "https://dummyimage.com/600x400/0E0B16/ffffff&text=Luftballon+20", Name = "Fashion Luftballon", Description = "Luftballon mit modischen Designs für Fashion-Events.", Price = 20.99, ArticleNumber = "LB-020", Stock = 100, InStock = true, CategoryId = 8 },
                new Product { Id = 21, ImageUrl = "https://dummyimage.com/600x400/FF0000/ffffff&text=Luftballon+21", Name = "Vintage Luftballon", Description = "Luftballon im Vintage-Stil für Retro-Partys.", Price = 21.99, ArticleNumber = "LB-021", Stock = 100, InStock = true, CategoryId = 9 }
                );



        }

    }
}
