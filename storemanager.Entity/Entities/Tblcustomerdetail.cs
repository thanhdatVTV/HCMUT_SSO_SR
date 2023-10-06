using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace storemanager.Entity.Entities
{
   
    public partial class Tblcustomerdetail
    {
        public Guid Id { get; set; }
        public Guid IdProduct { get; set; }
        public Guid IdCustomer { get; set; }
    }
}
