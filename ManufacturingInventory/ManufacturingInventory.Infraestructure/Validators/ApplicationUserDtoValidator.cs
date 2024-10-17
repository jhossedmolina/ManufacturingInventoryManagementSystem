using FluentValidation;
using ManufacturingInventory.Application.DTOs;

namespace ManufacturingInventory.Infraestructure.Validators
{
    public class ApplicationUserDtoValidator : AbstractValidator<ApplicationUserDto>
    {
        public ApplicationUserDtoValidator()
        {
            RuleFor(ru => ru.Name)
                .NotEmpty().WithMessage("El nombre no puede estar vacío");

            RuleFor(ru => ru.Email)
                .NotEmpty().WithMessage("El email no puede estar vacío")
                .EmailAddress().WithMessage("El email ingresado no es valido");

            RuleFor(ru => ru.Password)
                .NotEmpty().WithMessage("La contraseña no puede estar vacía")
                .MinimumLength(8).WithMessage("La contraseña debe tener minimo 8 caracteres.")
                .Matches("[A-Z]").WithMessage("La contraseña debe contener al menos una letra mayúscula.")
                .Matches("[a-z]").WithMessage("La contraseña debe contener al menos una letra minúscula.")
                .Matches("[0-9]").WithMessage("La contraseña debe contener al menos un número.")
                .Matches("[^a-zA-Z0-9]").WithMessage("La contraseña debe contener al menos un carácter especial.");
        }
    }
}
