using ARD.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ARD.Entity.Concrete
{
    public class District : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int ProvinceId { get; set; }
        public Province Province { get; set; }
    }
}
