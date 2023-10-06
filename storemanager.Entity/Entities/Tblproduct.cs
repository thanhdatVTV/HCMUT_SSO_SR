using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace storemanager.Entity.Entities
{    
    public partial class Tblproduct
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public Tblproduct(Guid id, string name, string price)
        {

            Id = id;
            Name = name;
            Price = price;
        }
    }
}
