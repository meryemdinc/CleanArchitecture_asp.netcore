using FluentValidation;


namespace App.Services.Products
{
    public class CreateProductRequestValidator:AbstractValidator<CreateProductRequest>
    {
        public CreateProductRequestValidator()
        {
          RuleFor(x => x.Name)
             .NotEmpty().WithMessage("Product name is required.")
            .Length(3,10).WithMessage("The product name must be between 3 and 10 characters.");
            //NotEmpty checks if the string is not null or empty
            //NotNull checks if the string is not null
          
            //price validation
            RuleFor(x => x.Price)
               
                .GreaterThan(0).WithMessage("The product price must be greater than zero.");
            //stock validation
            RuleFor(x => x.Stock)
                .InclusiveBetween(1,100).WithMessage("The stock quantity must be between 1 and 100.");


        }

    }
}
