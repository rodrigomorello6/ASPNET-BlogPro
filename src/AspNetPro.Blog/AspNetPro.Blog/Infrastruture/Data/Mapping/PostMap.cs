using AspNetPro.Blog.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AspNetPro.Blog.Infrastruture.Data.Mapping
{
    public class PostMap : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.ToTable("Posts");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title)
                .HasMaxLength(70)
                .IsRequired();

            builder.Property(x => x.Summary)
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(x => x.Content)
                .HasColumnType("longtext")
                .IsRequired();

            builder.Property(x => x.PublishedOn)
                .HasColumnType("datetime")
                .IsRequired();
        }
    }
}
