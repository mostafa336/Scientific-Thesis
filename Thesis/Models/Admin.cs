using System;
using System.Collections.Generic;

namespace Thesis.Models;

public partial class Admin
{
    public int AdId { get; set; }

    public string AdName { get; set; } = null!;

    public string AdEmail { get; set; } = null!;

    public string AdPassword { get; set; } = null!;

    public virtual ICollection<ModifiedApplication> ModifiedApplications { get; set; } = new List<ModifiedApplication>();
}
