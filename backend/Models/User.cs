using System;
using System.Collections.Generic;

namespace AngularBigBang.Models;

public partial class User
{
    public int Id { get; set; }

    public string? Email { get; set; }

    public string Name { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public string Gender { get; set; } = null!;

    public string Role { get; set; } = null!;

    public byte[]? Password { get; set; }

    public byte[]? HashKey { get; set; }
}
