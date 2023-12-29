namespace SupplyManagement.Models
{
    public class Vendor
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string BusinessField { get; set; }
        public string CompanyType { get; set; }
        public bool IsApprovedByAdmin { get; set; }
        public bool IsApprovedByLogisticsManager { get; set; }
        public Company Company { get; set; }
    }
}
