using System;
using System.Collections.Generic;

namespace Tasks.Infrastructure.Entities;

public partial class User
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string DocumentNumber { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateTime CreationDate { get; set; }

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
}
