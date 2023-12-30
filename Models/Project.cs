using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SupplyManagement.Models;

[Table("tb_m_projects")]
public class Project
{
    [Key]
    [Column("guid")]
    public Guid Guid { get; set; }
    [Column("project_name", TypeName = "nvarchar(100)")]
    public string ProjectName { get; set; }
    [Column("start_date")]
    public DateTime StartDate { get; set; }
    [Column("end_date")]
    public DateTime EndDate { get; set; }
    [Column("description", TypeName = "nvarchar(200)")]
    public string Description { get; set; }
    [Column("is_open_for_bidding")]
    public bool IsOpenForBidding { get; set; }
    public ICollection<Vendor> Vendors { get; set; } = new List<Vendor>();
}

