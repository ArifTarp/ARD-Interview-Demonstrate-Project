using ARD.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ARD.Entity.Concrete
{
    public class Address : IEntity
    {
        public Address()
        {
            Students = new List<Student>();
        }

        public int Id { get; set; }
        public string Province { get; set; }
        public string District { get; set; }

        public ICollection<Student> Students { get; set; }

    }
}
