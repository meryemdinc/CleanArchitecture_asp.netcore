namespace App.Repositories.Products;

   public class Product
    {
        public int Id { get; set; }
    public string Name { get; set; } = default!;//public required string Name { get; set; } .net 8 ile gelen özellik bizim yazdığımızın yerine bu tarz da yazılabilir default! yerine
    //default! kullanmamızın sebebi string? demedik yani null olabilir demedik bu yüzden string in default degeri null biz de default! diyerek ileride bu property'sinin null olmayacağını belirttik.
    public decimal Price{ get; set; }
        public int Stock{ get; set; }
    }

