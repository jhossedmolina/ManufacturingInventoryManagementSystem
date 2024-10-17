using ManufacturingInventory.Application.Enums;

namespace ManufacturingInventory.Application.DTOs
{
    public class ProductDto
    {
        public string Name { get; set; } = null!;

        public ProductionType ProductionType { get; set; }

        public ProductStatus Status { get; set; }
    }
}
