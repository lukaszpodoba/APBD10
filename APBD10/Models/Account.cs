using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APBD10.Models;

[Table("Accounts")]
public class Account
{
    [Key]
    [Column("PK_account")]
    public int AccountId { get; set; }
    [ForeignKey("Role")]
    [Column("FK_role")]
    public int RoleId { get; set; }
    [Column("first_name")]
    [MaxLength(50)]
    public string AccountFirstName { get; set; }
    [Column("last_name")]
    [MaxLength(50)]
    public string AccountLastName { get; set; }
    [Column("email")]
    [MaxLength(80)]
    public string AccountEmal { get; set; }
    [Column("phone")]
    [MaxLength(9)]
    public string? AccountPhone { get; set; }

    public Role Role { get; set; }
    public IEnumerable<ShoppingCart> ShoppingCarts { get; set; }
}