using ARD.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ARD.Entity.Concrete
{
    public class Student : IEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SchoolIdentity { get; set; }

        public Address Address { get; set; }
    }
}
