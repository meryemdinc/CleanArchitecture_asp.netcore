using App.Services.Products;
using App.Services.Products.Create;
using App.Services.Products.Update;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace App.API.Controllers
{
    public class ProductsController(IProductService productService) :CustomBaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()=>CreateActionResult(await productService.GetAllListAsync());
        [HttpGet("{pageNumber:int}/{pageSize:int}")]
        public async Task<IActionResult> GetPagedAll(int pageNumber,int pageSize) => CreateActionResult(await productService.GetPagedAllListAsync(pageNumber,pageSize));

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)=> CreateActionResult( await productService.GetByIdAsync(id));
        [HttpPost]
        public async Task<IActionResult> Create(CreateProductRequest request) => CreateActionResult(await productService.CreateAsync(request));

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, UpdateProductRequest request) => CreateActionResult(await productService.UpdateAsync(id, request));
        
        [HttpPatch("stock")] //swagger'da gözüksün diye buraya stock yazdık,stock'u güncelleyeceğiz.

        public async Task<IActionResult> UpdateStockAsync(UpdateProductStockRequest request) => CreateActionResult(await productService.UpdateStockAsync(request));


        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id) => CreateActionResult(await productService.DeleteAsync(id));
    }
}
//("{id}") ekleyerek bu id'nin route'dan geleceğini belirtiyoruz.
