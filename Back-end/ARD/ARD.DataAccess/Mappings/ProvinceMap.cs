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
                new Province { Name="Ankara" },
                new Province { Name = "İstanbul" },
                new Province { Name = "Bursa" },
                new Province { Name = "İzmir" }
            );
        }
    }
}
