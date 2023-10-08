using System;
using System.Collections.Generic;

namespace HCMUT_SSO.Models;

public partial class TblUser
{
    public Guid Id { get; set; }

    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int Type { get; set; }

    public virtual ICollection<TblStudent> TblStudents { get; set; } = new List<TblStudent>();

    public virtual ICollection<TblTeacher> TblTeachers { get; set; } = new List<TblTeacher>();
}
