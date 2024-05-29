namespace APBD10.PostModels;

public class PostProductModel
{
    public string productName { get; set; }
    public decimal productWeight { get; set; }
    public decimal productWidth { get; set; }
    public decimal productHeight { get; set; }
    public decimal productDepth { get; set; }
    
    public List<int> productCategories { get; set; }
}