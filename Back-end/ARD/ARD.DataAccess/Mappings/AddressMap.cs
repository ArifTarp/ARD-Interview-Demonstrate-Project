using ARD.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ARD.DataAccess.Mappings
{
    public class AddressMap : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Addresses");
            builder.HasKey(a => a.Id);

            builder.HasOne(a => a.Province).WithMany(p=>p.Addresses).HasForeignKey(a => a.ProvinceId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(a => a.District).WithMany(d => d.Addresses).HasForeignKey(a => a.DistrictId).OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(a => new { a.ProvinceId, a.DistrictId }).IsUnique();
        }
    }
}
