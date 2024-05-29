using APBD10.Contexts;
using APBD10.Exception;
using APBD10.Models;
using APBD10.PostModels;
using Microsoft.EntityFrameworkCore;

namespace APBD10.Services;

public interface IProductService
{
    Task<int> AddProductAsync(PostProductModel product);
}

public class ProductService(DatabaseContext context) : IProductService
{
    public async Task<int> AddProductAsync(PostProductModel product)
    {
        var result = new Product
        {
            ProductName = product.productName,
            ProductWeight = product.productWeight,
            ProductWidth = product.productWidth,
            ProductHeight = product.productHeight,
            ProductDepth = product.productDepth
        };
        
        await context.Products.AddAsync(result);
        await context.SaveChangesAsync();
        
        foreach (var categoryId in product.productCategories)
        {
            var responseCategory = await context.Categories.FindAsync(categoryId);
            if (responseCategory == null)
            {
                throw new BadRequestException($"Category with id: {categoryId} does not exists");
            }
        }
        
        foreach (var categoryId in product.productCategories)
        {
            var productCategory = new ProductCategory
            {
                ProductId = result.ProductId,
                CategoryId = categoryId
            };
            await context.ProductCategories.AddAsync(productCategory);
        }
        await context.SaveChangesAsync();
        
        return result.ProductId;
    }
}