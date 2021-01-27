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
        }
    }
}
