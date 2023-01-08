using System;
using System.Collections.Generic;

namespace EntityCoreTutorial.Models;

public partial class Account
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Emailid { get; set; }

    public string? Phonenumber { get; set; }

    public bool Isadmin { get; set; }

    public TimeOnly? Createddate { get; set; }

    public TimeOnly? Updatedate { get; set; }
}
