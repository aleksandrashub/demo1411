﻿using System;
using System.Collections.Generic;

namespace demo1411shubenok.Models;

public partial class Status
{
    public long IdStatus { get; set; }

    public string? Status1 { get; set; }

    public virtual ICollection<Zakaz> Zakazs { get; set; } = new List<Zakaz>();
}
