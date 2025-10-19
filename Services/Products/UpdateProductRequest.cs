
namespace App.Services.Products;
public record UpdateProductRequest( string Name, decimal Price, int Stock);
//int id parametresine gerek yok çünkü zaten servis katmanında id'yi parametre olarak alıyoruz ve orada güncelleme yaparken kullanıyoruz.