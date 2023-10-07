using System;
using System.Collections.Generic;

namespace HCMUT_SSO.Models;

public partial class TblCourse
{
    public Guid Id { get; set; }

    public string CourseName { get; set; } = null!;
}
