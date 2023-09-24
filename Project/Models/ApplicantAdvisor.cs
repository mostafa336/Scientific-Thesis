using System;
using System.Collections.Generic;

namespace Thesis.Models;

public partial class ApplicantAdvisor
{
    public int ApadId { get; set; }

    public int ApadApplicantId { get; set; }

    public string ApadAdvisorName { get; set; } = null!;

    public virtual FirstApplication ApadApplicant { get; set; } = null!;
}
