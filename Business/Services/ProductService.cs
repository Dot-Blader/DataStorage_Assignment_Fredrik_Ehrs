using Business.Factories;
using Business.Models;
using Data.Repositories;

namespace Business.Services;

public class ProductService(ProductRepository productRepository)
{
    private readonly ProductRepository _productRepository = productRepository;

    public async Task CreateProductAsync(ProductRegistrationForm form)
    {
        await _productRepository.BeginTransactionAsync();

        try
        {
            var productEntity = ProductFactory.Create(form);
            await _productRepository.AddAsync(productEntity!);

            await _productRepository.SaveAsync();
            await _productRepository.CommitTransactionAsync();
        }
        catch
        {
            await _productRepository.RollbackTransactionAsync();
        }
    }
    public async Task<IEnumerable<Product?>> GetProductsAsync()
    {
        var productEntities = await _productRepository.GetAsync();
        return productEntities.Select(ProductFactory.Create)!;
    }
    public async Task<Product?> GetProductByIdAsync(string id)
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
            _productRepository.Update(productEntity!);
            return true;
        }
        catch { return false; }
    }
    public async Task<bool> DeleteProductAsync(string id)
    {
        try
        {
            var productEntity = await _productRepository.GetAsync(x => x.Id == id);
            _productRepository.Delete(productEntity!);
            return true;
        }
        catch { return false; }
    }
}
