using System;
using System.Collections.Generic;

namespace Filmpoisk;

public partial class Film
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public virtual ICollection<Role> Roles { get; set; } = new List<Role>();
}
