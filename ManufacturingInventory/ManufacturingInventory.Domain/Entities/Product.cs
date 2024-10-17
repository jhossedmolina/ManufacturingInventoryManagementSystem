using System;
using System.Collections.Generic;

namespace ManufacturingInventory.Domain.Entities;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string ProductionType { get; set; } = null!;

    public string? Status { get; set; }
}
