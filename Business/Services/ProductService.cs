using Business.Factories;
using Business.Models;
using Data.Repositories;

namespace Business.Services;

public class ProductService(ProductRepository productRepository)
{
    private readonly ProductRepository _productRepository = productRepository;

    public async Task CreateProductAsync(ProductRegistrationForm form)
    {
        var productEntity = ProductFactory.Create(form);
        await _productRepository.AddAsync(productEntity!);
    }
    public async Task<IEnumerable<Product?>> GetProductsAsync()
    {
        var productEntities = await _productRepository.GetAsync();
        return productEntities.Select(ProductFactory.Create)!;
    }
    public async Task<Product?> GetProductByIdAsync(int id)
    {
        var productEntity = await _productRepository.GetAsync(x => x.Id == id);
        return ProductFactory.Create(productEntity!);
    }
    public async Task<Product?> GetProductByProductNameAsync(string name)
    {
        var productEntity = await _productRepository.GetAsync(x => x.ProductName == name);
        return ProductFactory.Create(productEntity!);
    }
    public async Task<bool> UpdateProductAsync(Product product)
    {
        try
        {
            var productEntity = await _productRepository.GetAsync(x => x.Id == product.Id);
            productEntity!.ProductName = product.ProductName;
            productEntity.Price = product.Price;
            await _productRepository.UpdateAsync(productEntity!);
            return true;
        }
        catch { return false; }
    }
    public async Task<bool> DeleteProductAsync(int id)
    {
        try
        {
            var productEntity = await _productRepository.GetAsync(x => x.Id == id);
            await _productRepository.DeleteAsync(productEntity!);
            return true;
        }
        catch { return false; }
    }
}
