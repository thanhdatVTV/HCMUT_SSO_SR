using System;
using System.Collections.Generic;

namespace HCMUT_SSO.Models;

public partial class TblStudent
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public string? LastName { get; set; }

    public string? FirstName { get; set; }

    public string? FullName { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public int? MajorId { get; set; }

    public Guid? ClassGroupId { get; set; }

    /// <summary>
    /// 0: Sinh vien; 1 Giao vien
    /// </summary>
    public int Type { get; set; }

    public virtual TblClassGroup? ClassGroup { get; set; }

    public virtual TblMajor? Major { get; set; }

    public virtual TblUser User { get; set; } = null!;
}
