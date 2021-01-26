using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ARD.API.DTOs
{
    public class StudentUpdateDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SchoolIdentity { get; set; }

        public int AddressId { get; set; }
    }
}
