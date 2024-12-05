using System;
using System.Collections.Generic;

namespace Assessment_Preparation.Models;

public partial class Book
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Author { get; set; }

    public int? Price { get; set; }
}
