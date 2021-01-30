using ARD.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ARD.Entity.DTOs
{
    public class AddressAddForMapDto
    {
        public Province Province { get; set; }
        public District District { get; set; }
        public AddressAddDto AddressAddDto { get; set; }

    }
}
