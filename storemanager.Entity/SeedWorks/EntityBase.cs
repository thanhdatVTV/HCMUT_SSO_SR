using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace storemanager.Entity.SeedWorks
{
    public abstract class EntityBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public virtual int Id { get; set; }

        public virtual Guid Id { get; set; }
        public virtual DateTime UpdatedDate { get; set; }
        public virtual DateTime CreatedDate { get; set; }
    }
}