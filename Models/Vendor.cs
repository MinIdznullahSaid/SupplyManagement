using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SupplyManagement.Models;

[Table("tb_m_vendors")]
public class Vendor
{
    [Key]
    [Column("guid")]
    public Guid Guid { get; set; }
    [Column("company_guid")]
    public Guid CompanyGuid { get; set; }
    [Column("businees_field", TypeName = "nvarchar(20)")]
    public string BusinessField { get; set; }
    [Column("company_type", TypeName = "nvarchar(20)")]
    public string CompanyType { get; set; }
    [Column("is_approved_by_admin")]
    public bool IsApprovedByAdmin { get; set; }
    [Column("is_approved_by_manager")]
    public bool IsApprovedByManager { get; set; }

    public Company Company { get; set; }
    public ICollection<Project> Projects { get; set; } = new List<Project>();
    public ICollection<VendorApproval> VendorApprovals { get; set; }
}

