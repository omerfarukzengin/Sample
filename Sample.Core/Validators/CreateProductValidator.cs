using FluentValidation;
using Sample.Core.Features.Products.Commands;

namespace Sample.Core.Validators
{
    public class CreateProductValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductValidator()
        {
            RuleFor(product => product.Title)
                .Must(f => !string.IsNullOrWhiteSpace(f)).WithMessage(f => "Title can not be empty.")
                .MaximumLength(200).WithMessage(f => "Title can not have more than 200 characters.");
        }
    }
}
