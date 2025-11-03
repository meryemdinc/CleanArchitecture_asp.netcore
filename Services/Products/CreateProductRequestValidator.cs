using App.Repositories.Products;
using FluentValidation;


namespace App.Services.Products
{
    public class CreateProductRequestValidator:AbstractValidator<CreateProductRequest>
    {
        private readonly IProductRepository _productRepository;
        public CreateProductRequestValidator(IProductRepository productRepository)
        {
            _productRepository = productRepository;
            RuleFor(x => x.Name)
               .NotEmpty().WithMessage("Product name is required.")
              .Length(3, 10).WithMessage("The product name must be between 3 and 10 characters.")
              .Must(MustUniqueProductName).WithMessage("This product name already exists in the database.");
            //NotEmpty checks if the string is not null or empty
            //NotNull checks if the string is not null
          
            //price validation
            RuleFor(x => x.Price)
               
                .GreaterThan(0).WithMessage("The product price must be greater than zero.");
            //stock validation
            RuleFor(x => x.Stock)
                .InclusiveBetween(1,100).WithMessage("The stock quantity must be between 1 and 100.");


        }

        private bool MustUniqueProductName(string name)
        {
            return !_productRepository.Where(x=> x.Name == name).Any(); //Any() ile aynı isimli varsa true döndürür,
                                                                        //aynı verinin databasede olması bir hata olduğu için false dönmesi amaçlı '!' ekledik.
            //return false,hata var
            //return true,hata yok anlamına geliyor 

        }

    }
}
