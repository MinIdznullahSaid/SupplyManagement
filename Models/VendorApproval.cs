namespace SupplyManagement.Models
{
    public class VendorApproval
    {
        public int Id { get; set; }
        public int VendorId { get; set; }
        public int ApprovedByUserId { get; set; }
        public DateTime ApprovalDate { get; set; }
        public Vendor Vendor { get; set; }
        public User ApprovedByUser { get; set; }
    }
}
