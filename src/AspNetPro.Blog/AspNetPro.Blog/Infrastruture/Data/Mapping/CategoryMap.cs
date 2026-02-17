using AspNetPro.Blog.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZstdSharp;

namespace AspNetPro.Blog.Infrastruture.Data.Mapping
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");
            builder.HasKey(c => c.Id);

            builder.Property(x => x.Name)
                    .IsRequired()
                    .HasMaxLength(70);

            builder.HasMany(x => x.Posts)
                .WithOne(x => x.Category);

        }
            
    }
}
