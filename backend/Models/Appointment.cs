using System;
using System.Collections.Generic;

namespace AngularBigBang.Models;

public partial class Appointment
{
    public int Appointmentid { get; set; }

    public string? Pusername { get; set; }

    public string? Dusername { get; set; }

    public int? Age { get; set; }

    public DateTime? Date { get; set; }
}
