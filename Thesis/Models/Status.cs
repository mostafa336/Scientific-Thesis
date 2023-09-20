using System;
using System.Collections.Generic;

namespace Thesis.Models;

public partial class Status
{
    public int StId { get; set; }

    public string StState { get; set; } = null!;

    public virtual ICollection<ModifiedApplication> ModifiedApplications { get; set; } = new List<ModifiedApplication>();
}
