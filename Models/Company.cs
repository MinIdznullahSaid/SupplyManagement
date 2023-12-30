using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SupplyManagement.Models;

[Table("tb_m_companies")]
public class Company
{
    [Key]
    [Column("guid")]
    public Guid Guid { get; set; }
    [Column("name", TypeName = "nvarchar(100)")]
    public string Name { get; set; }
    [Column("registration_number", TypeName = "nchar(6)")]
    public string RegistrationNumber { get; set; }
    [Column("address", TypeName = "nvarchar(100)")]
    public string Address { get; set; }
    [Column("email", TypeName = "nvarchar(100)")]
    public string Email { get; set; }
    [Column("phone_number", TypeName = "nvarchar(20)")]
    public string PhoneNumber { get; set; }
    [Column("photo_url", TypeName = "nvarchar(100)")]
    public string PhotoUrl { get; set; }
    [Column("is_approved")]
    public bool IsApproved { get; set; }

    public ICollection<Vendor> Vendors { get; set; }
}

