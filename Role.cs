using System;
using System.Collections.Generic;

namespace Filmpoisk;

public partial class Role
{
    public int Id { get; set; }

    public int? FilmsId { get; set; }

    public int? ActorsId { get; set; }

    public virtual Actor? Actors { get; set; }

    public virtual Film? Films { get; set; }
}
