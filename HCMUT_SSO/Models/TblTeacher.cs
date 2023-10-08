using System;
using System.Collections.Generic;

namespace HCMUT_SSO.Models;

public partial class TblTeacher
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public string TeacherId { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public DateTime? DateOfBirth { get; set; }

    public int CourseId { get; set; }

    public virtual TblCourse Course { get; set; } = null!;

    public virtual TblUser User { get; set; } = null!;
}
