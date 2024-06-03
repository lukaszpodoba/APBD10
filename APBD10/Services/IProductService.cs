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
    public void Validation(PostProductModel productData)
    {
        if (string.IsNullOrWhiteSpace(productData.productName))
        {
            throw new BadRequestException("Product name cannot be empty");
        }

        if (productData.productWeight is <= 0 or > 999.99m)
        {
            throw new BadRequestException("Product weight must be greater than zero and less than 999.99.");
        }

        if (productData.productWidth is <= 0 or > 999.99m)
        {
            throw new BadRequestException("Width of the product must be greater than zero and less than 999.99.");
        }

        if (productData.productHeight is <= 0 or > 999.99m)
        {
            throw new BadRequestException("Height of the product must be greater than zero and less than 999.99.");
        }

        if (productData.productDepth is <= 0 or > 999.99m)
        {
            throw new BadRequestException("Depth of the product must be greater than zero and less than 999.99.");
        }
    }
    
    public async Task<int> AddProductAsync(PostProductModel product)
    {
        Validation(product);
        
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