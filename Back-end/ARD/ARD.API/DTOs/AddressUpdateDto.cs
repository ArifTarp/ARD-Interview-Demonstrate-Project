﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ARD.API.DTOs
{
    public class AddressUpdateDto
    {
        public int Id { get; set; }
        public string Province { get; set; }
        public string District { get; set; }
    }
}