namespace ManufacturingInventory.Application.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string ProductionType { get; set; } = null!;

        public string? Status { get; set; }
    }
}
