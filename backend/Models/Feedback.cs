using System;
using System.Collections.Generic;

namespace AngularBigBang.Models;

public partial class Feedback
{
    public int Feedbackid { get; set; }

    public string? Pusername { get; set; }

    public string? Dusername { get; set; }

    public string? Details { get; set; }
}
