using System;
using System.Collections.Generic;

namespace AngularBigBang.Models;

public partial class Doctor
{
    public int Id { get; set; }

    public string? Email { get; set; }

    public string Name { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public string Gender { get; set; } = null!;

    public string Role { get; set; } = null!;

    public string Specialization { get; set; } = null!;

    public int Experiance { get; set; }

    public string RequestStatus { get; set; } = null!;

    public string Availability { get; set; } = null!;

    public string Password { get; set; } = null!;
}
