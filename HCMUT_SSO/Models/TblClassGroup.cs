using System;
using System.Collections.Generic;

namespace HCMUT_SSO.Models;

public partial class TblClassGroup
{
    public Guid Id { get; set; }

    public string ClassGroupName { get; set; } = null!;

    public virtual ICollection<TblStudent> TblStudents { get; set; } = new List<TblStudent>();
}
