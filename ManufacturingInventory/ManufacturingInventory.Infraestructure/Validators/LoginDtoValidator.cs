using FluentValidation;
using ManufacturingInventory.Application.DTOs;

namespace ManufacturingInventory.Infraestructure.Validators
{
    public class LoginDtoValidator : AbstractValidator<LoginDto>
    {
        public LoginDtoValidator()
        {
            RuleFor(ru => ru.Email)
                .NotEmpty().WithMessage("El email no puede estar vacío")
                .EmailAddress().WithMessage("El email ingresado no es valido");

            RuleFor(ru => ru.Password)
                .NotEmpty().WithMessage("La contraseña no puede estar vacía");
        }
    }
}
