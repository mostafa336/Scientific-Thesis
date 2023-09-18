using System;
using System.Collections.Generic;

namespace ScienteficThesis.Models;

public partial class University
{
    public int UniId { get; set; }

    public string UniNameAr { get; set; } = null!;

    public string UniNameEn { get; set; } = null!;

    public virtual ICollection<FirstApplication> FirstApplications { get; set; } = new List<FirstApplication>();

    public virtual ICollection<ModifiedApplication> ModifiedApplications { get; set; } = new List<ModifiedApplication>();
}
