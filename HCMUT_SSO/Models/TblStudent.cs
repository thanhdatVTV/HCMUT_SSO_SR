﻿using System;
using System.Collections.Generic;

namespace HCMUT_SSO.Models;

public partial class TblStudent
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public string StudentId { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public DateTime? DateOfBirth { get; set; }

    public int MajorId { get; set; }

    public Guid ClassGroupId { get; set; }

    public virtual TblClassGroup ClassGroup { get; set; } = null!;

    public virtual TblMajor Major { get; set; } = null!;

    public virtual TblUser User { get; set; } = null!;
}
