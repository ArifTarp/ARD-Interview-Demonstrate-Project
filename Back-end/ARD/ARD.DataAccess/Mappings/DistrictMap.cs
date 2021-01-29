using ARD.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ARD.DataAccess.Mappings
{
    public class DistrictMap : IEntityTypeConfiguration<District>
    {
        public void Configure(EntityTypeBuilder<District> builder)
        {
            builder.ToTable("Districts");
            builder.HasKey(d => d.Id);

            builder.HasOne(d => d.Province).WithMany(p => p.Districts).HasForeignKey(d => d.provinceId).OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(d => new { d.Name, d.provinceId }).IsUnique();

            builder.HasData(
                new District { Name = "Yenimahalle", provinceId = 1},
                new District { Name = "Çankaya", provinceId = 1 },
                new District { Name = "Bahçeşehir", provinceId = 2 },
                new District { Name = "Beyoğlu", provinceId = 2 },
                new District { Name = "Osmangazi", provinceId = 3 },
                new District { Name = "İnegöl", provinceId = 3 },
                new District { Name = "Selçuk", provinceId = 4 },
                new District { Name = "Seferihisar", provinceId = 4 }
            );
        }
    }
}
