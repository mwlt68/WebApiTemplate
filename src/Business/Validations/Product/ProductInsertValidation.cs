using DataAccess.Consts;
using DataAccess.Dtos.Product;
using FluentValidation;

namespace Business.Validations.Product
{
    public class ProductInsertValidation : AbstractValidator<ProductInsertDto>
    {
        public ProductInsertValidation()
        {
            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .WithMessage("Name cannot be left")
                .MaximumLength(ProductConsts.NameMaxLength)
                .WithErrorCode($"Name must be less than {ProductConsts.NameMaxLength} characters !");
            RuleFor(x => x.Category)
                .NotNull()
                .NotEmpty()
                .WithMessage("Category cannot be left")
                .MaximumLength(ProductConsts.CategoryMaxLength)
                .WithErrorCode($"Category must be less than {ProductConsts.CategoryMaxLength} characters !");
            RuleFor(x => x.Brand)
                .NotNull()
                .NotEmpty()
                .WithMessage("Brand cannot be left")
                .MaximumLength(ProductConsts.BrandMaxLength)
                .WithErrorCode($"Brand must be less than {ProductConsts.BrandMaxLength} characters !");
            RuleFor(x => x.StockQuantity)
                .GreaterThanOrEqualTo(0)
                .WithErrorCode($"Stock quantity cannot be negative !");
            RuleFor(x => x.Price)
                .GreaterThanOrEqualTo(0)
                .WithErrorCode($"Price cannot be negative !");
        }
    }
}
