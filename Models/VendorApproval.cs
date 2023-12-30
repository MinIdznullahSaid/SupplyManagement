using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SupplyManagement.Models;

[Table("tb_tr_vendor_approvals")]
public class VendorApproval
{
    [Key]
    [Column("guid")]
    public Guid Guid { get; set; }
    [Column("vendor_guid")]
    public Guid VendorGuid { get; set; }
    [Column("approved_by_user_guid")]
    public Guid ApprovedByUserGuid { get; set; }
    [Column("approval_date")]
    public DateTime ApprovalDate { get; set; }
    public Vendor Vendor { get; set; }
    public User ApprovedByUser { get; set; }
    public User User { get; set; }

}

