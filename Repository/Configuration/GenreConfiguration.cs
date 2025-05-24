using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Repository.Configuration
{
    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.HasData(
                new Genre
                {
                    Id = new Guid("a1e1c1b0-1f2a-4b3c-9d4e-5f6a7b8c9d0e"),
                    Title = "Science Fiction",
                },
                new Genre
                {
                    Id = new Guid("b2f2d2c1-2e3b-5c4d-8e5f-6a7b8c9d0e1f"),
                    Title = "Fantasy",
                },
                new Genre
                {
                    Id = new Guid("c3a3e3d2-3f4c-6d5e-7f8a-9b0c1d2e3f4a"),
                    Title = "Mystery",
                },
                new Genre
                {
                    Id = new Guid("d4b4f4e3-4a5d-7e6f-8a9b-0c1d2e3f4a5b"),
                    Title = "Romance",
                },
                new Genre
                {
                    Id = new Guid("e5c5a5f4-5b6e-8f7a-9b0c-1d2e3f4a5b6c"),
                    Title = "Horror",
                }
            );
        }
    }
}
