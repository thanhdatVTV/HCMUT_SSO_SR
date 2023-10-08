using System;
using System.Collections.Generic;

namespace HCMUT_SSO.Models;

public partial class TblMajor
{
    public int Id { get; set; }

    public int FacultyId { get; set; }

    public string MajorName { get; set; } = null!;

    public virtual TblFaculty Faculty { get; set; } = null!;

    public virtual ICollection<TblStudent> TblStudents { get; set; } = new List<TblStudent>();
}
