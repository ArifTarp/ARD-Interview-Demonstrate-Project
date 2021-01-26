﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ARD.API.DTOs
{
    public class AddressUpdateDto
    {
        public int Id { get; set; }
        public int ProvinceId { get; set; }
        public int DistrictId { get; set; }
        public string AddressDetail { get; set; }
    }
}
