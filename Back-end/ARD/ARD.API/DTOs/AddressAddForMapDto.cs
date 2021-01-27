using ARD.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ARD.API.DTOs
{
    public class AddressAddForMapDto
    {
        public Province Province { get; set; }
        public District District { get; set; }
        public AddressAddDto AddressAddDto { get; set; }

    }
}
