using System;
using DomainLayer.Models;

namespace DomainLayer.Data
{
    public static class DbInitializer
    {
        public static void Initialize(LibraryDbContext context)
        {
            context.Database.EnsureCreated();

            // Look for any Books.
            if (context.Books.Any())
            {
                return;   // DB has been seeded
            }

            var books = new Book[]
            {
                new Book{IsActive = true, PublishDate = DateTime.Parse("2022/11/11")
                , CreatedDate = DateTime.Now
                , Title = "Apps and Services with .NET 7: Build practical projects with Blazor, .NET MAUI, gRPC, GraphQL, and other enterprise techno...\r\nApps and Services with .NET 7: Build practical projects with Blazor, .NET MAUI, gRPC, GraphQL, and other enterprise technologies"
                , Publisher = "Packt"
                }
            };
            foreach (var book in books)
            {
                context.Books.Add(book);
            }

            context.SaveChanges();

            var authors = new Author[]
            {
                new Author{FirstName = "Mark J." , LastName = "Price", CreatedDate = DateTime.Now, IsActive = true }
            };
            foreach (var author in authors)
            {
                context.Authors.Add(author);
            }
            context.SaveChanges();

        }
    }
}
