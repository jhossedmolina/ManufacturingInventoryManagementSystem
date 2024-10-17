using FluentValidation;
using ManufacturingInventory.Application.DTOs;

namespace ManufacturingInventory.Infraestructure.Validators
{
    public class ProductDtoValidator : AbstractValidator<ProductDto>
    {
        public ProductDtoValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("El nombre no puede estar vacío");

            RuleFor(p => p.ProductionType)
                .NotEmpty().WithMessage("El tipo de elaboración no puede estar vacío")
                .IsInEnum().WithMessage("El tipo de producción debe ser uno de los tipos válidos: 1 = Elaborado A Mano, 2 = Elaborado A Mano Y Máquina");

            RuleFor(p => p.Status)
                .NotEmpty().WithMessage("El estado no puede estar vacío")
                .IsInEnum().WithMessage("El tipo de producción debe ser uno de los tipos válidos: 1 = En Stock, 2 = Defectuoso, 3 = Fuera De Stock");
        }
    }
}
