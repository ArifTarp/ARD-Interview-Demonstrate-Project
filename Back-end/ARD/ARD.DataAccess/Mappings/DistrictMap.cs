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
            builder.HasKey(s => s.Id);

            builder.HasOne(d => d.Province).WithMany(p => p.Districts).HasForeignKey(d => d.ProvinceId);
        }
    }
}
