﻿using System;
using System.Collections.Generic;

namespace HCMUT_SSO.Models;

public partial class TblFaculty
{
    public int Id { get; set; }

    public int CourseId { get; set; }

    public string FacultyName { get; set; } = null!;
}
