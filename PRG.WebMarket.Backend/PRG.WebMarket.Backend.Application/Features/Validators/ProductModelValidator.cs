using FluentValidation;
using PRG.WebMarket.Backend.Domain.Model;

namespace PRG.WebMarket.Backend.Application.Features.Validators
{
    public  class ProductModelValidator : AbstractValidator<ProductModel>
    {
        public ProductModelValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("El campo nombre es obligatorio")
                .Length(2, 50)
                .WithMessage("El nombre del producto debe tener entre 2 y 50 caracteres.");
            RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage("El campo descripcion es obligatorio")
                .Length(10, 200)
                .WithMessage("La descripcion debe tener entre 2 y 50 caracteres.");
            RuleFor(x => x.Price)
                .GreaterThan(0)
                .WithMessage("El precio debe ser mayor que 0");
            RuleFor(x => x.Stock)
                .GreaterThanOrEqualTo(0)
                .WithMessage("El stock debe ser mayor o igual a 0");

        }
    }
}
