using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace storemanager.Entity.Entities
{
    
    public partial class Tblshopdetail
    {
        public Guid Id { get; set; }
        public Guid IdShop { get; set; }
        public Guid IdProduct { get; set; }
    }
}
