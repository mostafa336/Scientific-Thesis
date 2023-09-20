using System;
using System.Collections.Generic;

namespace Thesis.Models;

public partial class Degree
{
    public int DegId { get; set; }

    public string DegNameAr { get; set; } = null!;

    public string DegNameEn { get; set; } = null!;

    public virtual ICollection<FirstApplication> FirstApplications { get; set; } = new List<FirstApplication>();

    public virtual ICollection<ModifiedApplication> ModifiedApplications { get; set; } = new List<ModifiedApplication>();
}
