using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SupplyManagement.Models;

[Table("tb_m_users")]
public class User
{
    [Key]
    [Column("guid")]
    public Guid Guid { get; set; }
    [Column("user_name", TypeName = "nvarchar(100)")]
    public string Username { get; set; }
    [Column("password")]
    public string Password { get; set; }
    [Column("role")]
    public string Role { get; set; }
    public ICollection<VendorApproval> VendorApprovals { get; set; }
}

