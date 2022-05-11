using System.Text.Json;
using ApiaryDiary.Modules.Users.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiaryDiary.Modules.Users.Core.DAL.Configurations;

public class UserConfigurations : IEntityTypeConfiguration<User>
{
    private static JsonSerializerOptions SerializerOptions = new()
    {
        PropertyNameCaseInsensitive = true
    };
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasIndex(x => x.Email).IsUnique();
        builder.Property(x => x.Password).IsRequired();
        builder.Property(x => x.Role).IsRequired();
        builder.Property(x => x.Claims)
            .HasConversion(x => JsonSerializer.Serialize(x, SerializerOptions),
                x => JsonSerializer.Deserialize<Dictionary<string, IEnumerable<string>>>(x, SerializerOptions));
    }
}