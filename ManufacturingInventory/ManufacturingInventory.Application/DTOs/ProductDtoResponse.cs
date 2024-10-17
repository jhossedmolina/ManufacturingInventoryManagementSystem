namespace ManufacturingInventory.Application.DTOs
{
    public class ProductDtoResponse
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string ProductionType { get; set; } = null!;

        public string? Status { get; set; }
    }
}
