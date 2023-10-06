using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace storemanager.Entity.Entities
{   
    public partial class Tblcustomer
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public DateTime Dob { get; set; }
        public string Email { get; set; }
       
        //public bool? IsDelete { get; set; }
        public Tblcustomer(Guid id,string fullName,DateTime dob,string email)
        {
            Id = id;
            FullName = fullName;
            Dob = dob;
            Email = email;
          
        }
    }
}
