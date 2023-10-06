using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace storemanager.Entity.Entities
{
    
    public partial class Tblshop
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

        public Tblshop(Guid id, string name, string location)
        {
            Id = id;
            Name = name;
            Location = location;
        }
    }
}
