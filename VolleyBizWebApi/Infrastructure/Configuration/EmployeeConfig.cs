using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VolleyBizWebApi.Domain.Entities;

namespace VolleyBizWebApi.Infrastructure.Configuration
{
    public class EmployeeConfig : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.Name).IsRequired().HasColumnType("nvarchar").HasMaxLength(255);
            builder.Property(x => x.Dob).IsRequired().HasColumnType("datetime");
            builder.Property(x => x.MartialStatus).HasColumnType("int");
            builder.Property(x => x.Gender).IsRequired().HasColumnType("int");
            builder.Property(x => x.Image).IsRequired().HasColumnType("nvarchar(max)");
        }
    }
}