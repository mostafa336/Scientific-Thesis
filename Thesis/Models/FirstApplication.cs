using System;
using System.Collections.Generic;

namespace Thesis.Models;

public partial class FirstApplication
{
    public int AppId { get; set; }

    public string AppNameAr { get; set; } = null!;

    public string AppNameEn { get; set; } = null!;

    public string AppEmail { get; set; } = null!;

    public DateTime AppBirthDate { get; set; }

    public string? AppJob { get; set; }

    public int? AppNationalityId { get; set; }

    public string AppNationalId { get; set; } = null!;

    public string AppThesisTitleAr { get; set; } = null!;

    public string AppThesisTitleEn { get; set; } = null!;

    public short? AppVolumes { get; set; }

    public short AppPages { get; set; }

    public short? AppPublicationYear { get; set; }

    public string AppDepartment { get; set; } = null!;

    public string AppFaculty { get; set; } = null!;

    public int? AppUniversityId { get; set; }

    public string AppKeyword { get; set; } = null!;

    public string AppNotes { get; set; } = null!;

    public string AppSubmissionLetter { get; set; } = null!;

    public string AppThesis { get; set; } = null!;

    public DateTime AppSubmissionTime { get; set; }

    public string AppLanguageMaster { get; set; } = null!;

    public int AppDegreeId { get; set; }

    public virtual Degree AppDegree { get; set; } = null!;

    public virtual Country? AppNationality { get; set; }

    public virtual University? AppUniversity { get; set; }

    public virtual ModifiedApplication? ModifiedApplication { get; set; }
}
