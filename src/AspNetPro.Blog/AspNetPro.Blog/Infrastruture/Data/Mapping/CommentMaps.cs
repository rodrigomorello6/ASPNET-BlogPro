using AspNetPro.Blog.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AspNetPro.Blog.Infrastruture.Data.Mapping
{
    public class CommentMaps : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("Posts_Comments");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Author)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.Content)
                .HasColumnType("LONGTEXT");

            builder.HasOne(x => x.Post)
                .WithMany(x => x.Comments);
        }
    }
}
