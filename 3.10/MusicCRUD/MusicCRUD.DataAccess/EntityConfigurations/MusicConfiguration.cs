using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicCRUD.DataAccess.Entity;

namespace MusicCRUD.DataAccess.EntityConfigurations;

public class MusicConfiguration : IEntityTypeConfiguration<Music>
{
    public void Configure(EntityTypeBuilder<Music> builder)
    {
        builder.ToTable("Music");

        builder.HasKey(m => m.MusicId);

        builder.Property(m => m.Name)
            .HasMaxLength(30);

        builder.Property(m => m.Description)
            .HasMaxLength(50);

        builder.Property(m => m.AuthorName) 
            .HasMaxLength(20);

        builder.HasMany(m => m.Comments)
            .WithOne(m => m.Music)
            .HasForeignKey(c => c.MusicId);
            
    }
}
