using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ARD.Entity.DTOs
{
    public class AddressUpdateDto
    {
        public int Id { get; set; }
        public string ProvinceName { get; set; }
        public string DistrictName { get; set; }
        public string AddressDetail { get; set; }
    }
}
