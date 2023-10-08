using System;
using System.Collections.Generic;

namespace HCMUT_SSO.Models;

public partial class TblCourse
{
    public int Id { get; set; }

    public string CourseName { get; set; } = null!;

    public virtual ICollection<TblFaculty> TblFaculties { get; set; } = new List<TblFaculty>();

    public virtual ICollection<TblTeacher> TblTeachers { get; set; } = new List<TblTeacher>();
}
