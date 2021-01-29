using ARD.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ARD.Entity.Concrete
{
    public class Address : IEntity
    {
        public int Id { get; set; }
        public string AddressDetail { get; set; }


        public int ProvinceId { get; set; }
        public Province Province { get; set; }
        public int DistrictId { get; set; }
        public District District { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }

    }
}
