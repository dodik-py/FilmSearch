using System;
using System.Collections.Generic;

namespace Filmpoisk;

public partial class Actor
{
    public string Name { get; set; } = null!;

    public string? Surname { get; set; }

    public int Id { get; set; }

    public virtual ICollection<Role> Roles { get; set; } = new List<Role>();
}
