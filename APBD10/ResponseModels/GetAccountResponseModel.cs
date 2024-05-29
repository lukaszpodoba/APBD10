namespace APBD10.ResponseModels;

public class GetAccountResponseModel
{
    public string firstName { get; set; }
    public string lastName { get; set; }
    public string emial { get; set; }
    public string? phone { get; set; }
    public string role { get; set; }
    public IEnumerable<GetShoppingCartRsponseModel> shoppingCarts { get; set; }
}