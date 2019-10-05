using System;
using System.Collections.Generic;

namespace ErpCore.Domain
{
    public partial class Person
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        public virtual Client Client { get; set; }
    }
}
