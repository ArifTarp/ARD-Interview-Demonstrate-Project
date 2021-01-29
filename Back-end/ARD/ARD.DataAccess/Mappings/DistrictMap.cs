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
                new District { Id = 1, Name = "Yenimahalle", provinceId = 1},
                new District { Id = 2, Name = "Çankaya", provinceId = 1 },
                new District { Id = 3, Name = "Bahçeşehir", provinceId = 2 },
                new District { Id = 4, Name = "Beyoğlu", provinceId = 2 },
                new District { Id = 5, Name = "Osmangazi", provinceId = 3 },
                new District { Id = 6, Name = "İnegöl", provinceId = 3 },
                new District { Id = 7, Name = "Selçuk", provinceId = 4 },
                new District { Id = 8, Name = "Seferihisar", provinceId = 4 }
            );
        }
    }
}
