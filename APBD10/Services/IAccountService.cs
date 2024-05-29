using APBD10.Contexts;
using APBD10.Exception;
using APBD10.PostModels;
using APBD10.ResponseModels;
using Microsoft.EntityFrameworkCore;

namespace APBD10.Services;

public interface IAccountService
{
    Task<GetAccountResponseModel?> GetAccountByIdAsync(int accountId);
}

public class AccountService(DatabaseContext context) : IAccountService
{
    public async Task<GetAccountResponseModel?> GetAccountByIdAsync(int accountId)
    {
        var response = await context.Accounts
            .Where(a => a.AccountId == accountId)
            .Select(a => new GetAccountResponseModel
            {
                firstName = a.AccountFirstName,
                lastName = a.AccountLastName,
                emial = a.AccountEmal,
                phone = a.AccountPhone,
                role = a.Role.RoleName,
                shoppingCarts = a.ShoppingCarts.Select(sc => new GetShoppingCartRsponseModel
                {
                    productId = sc.ProductId,
                    productName = sc.Product.ProductName,
                    amount = sc.ShoppingCartAmount
                })
            })
            .FirstOrDefaultAsync();

        if (response == null)
        {
            throw new NotFoundException($"Account with id: {accountId} does not exists");
        }
        
        return response;
    }
}