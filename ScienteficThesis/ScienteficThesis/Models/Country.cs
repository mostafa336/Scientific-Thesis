using System;
using System.Collections.Generic;

namespace ScienteficThesis.Models;

public partial class Country
{
    public int CntId { get; set; }

    public string CntNameAr { get; set; } = null!;

    public string CntNameEn { get; set; } = null!;

    public virtual ICollection<FirstApplication> FirstApplications { get; set; } = new List<FirstApplication>();

    public virtual ICollection<ModifiedApplication> ModifiedApplications { get; set; } = new List<ModifiedApplication>();
}
