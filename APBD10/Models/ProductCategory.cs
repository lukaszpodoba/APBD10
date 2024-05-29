using System.ComponentModel.DataAnnotations.Schema;

namespace APBD10.Models;

[Table("Products_Categories")]
public class ProductCategory
{
    [Column("Fk_product")]
    [ForeignKey("Product")]
    public int ProductId { get; set; }
    [Column("FK_category")]
    [ForeignKey("Category")]
    public int CategoryId { get; set; }
    
    public Product Product { get; set; }
    public Category Category { get; set; }
}