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

    public int? IndustryId { get; set; }

    public Guid? ClassGroupId { get; set; }
}
