using ARD.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ARD.DataAccess.Mappings
{
    public class ProvinceMap : IEntityTypeConfiguration<Province>
    {
        public void Configure(EntityTypeBuilder<Province> builder)
        {
            builder.ToTable("Provinces");
            builder.HasKey(p => p.Id);

            builder.HasData(
                new Province { Id = 1, Name="Ankara" },
                new Province { Id = 2, Name = "İstanbul" },
                new Province { Id = 3, Name = "Bursa" },
                new Province { Id = 4, Name = "İzmir" }
            );
        }
    }
}
