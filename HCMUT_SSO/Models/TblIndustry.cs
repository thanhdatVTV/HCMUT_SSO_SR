using System;
using System.Collections.Generic;

namespace HCMUT_SSO.Models;

public partial class TblIndustry
{
    public int Id { get; set; }

    public int FacultyId { get; set; }

    public string IndustryName { get; set; } = null!;
}
