﻿using System;
using System.Collections.Generic;

namespace demo1411shubenok.Models;

public partial class Punkt
{
    public long IdPunkt { get; set; }

    public string? Punkt1 { get; set; }

    public virtual ICollection<Zakaz> Zakazs { get; set; } = new List<Zakaz>();
}
