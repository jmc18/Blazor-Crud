using BlazorCrud.Web.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlazorCrud.Web.EntitiesConfiguration;
public class PersonConfig : IEntityTypeConfiguration<Person>
{

    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.ToTable("Person");
        builder.HasKey(_ => _.PersonId);
        builder.Property(_ => _.PersonId).ValueGeneratedOnAdd();
        builder.Property(_ => _.Name).HasMaxLength(80).IsRequired();
        builder.Property(_ => _.FirstName).HasMaxLength(80).IsRequired(false);
        builder.Property(_ => _.LastName).HasMaxLength(80).IsRequired();
        builder.Property(_ => _.Email).IsUnicode().IsRequired();
        builder.Property(_ => _.Phone).IsRequired(false);
        builder.Property(_ => _.Address).IsRequired(false);
    }
}

