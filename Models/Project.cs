namespace SupplyManagement.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string ProjectName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
        public bool IsOpenForBidding { get; set; }
        public ICollection<Vendor> Vendors { get; set; }
    }
}
