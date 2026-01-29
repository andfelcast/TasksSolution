using System;
using System.Collections.Generic;

namespace Tasks.Domain.Entities;

public partial class Task
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int UserId { get; set; }

    public int StatusId { get; set; }    

    public int Duration { get; set; }

    public DateTime CreationDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public string? AdditionalInfo { get; set; }

    public virtual Status Status { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
