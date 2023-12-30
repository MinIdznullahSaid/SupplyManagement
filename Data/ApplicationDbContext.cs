using Microsoft.EntityFrameworkCore;
using SupplyManagement.Models;

namespace API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Company> Companies { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<VendorApproval> VendorApprovals { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Konfigurasi model

            // Many Vendors with One Company (N:1)
            modelBuilder.Entity<Vendor>()
                        .HasOne(v => v.Company)
                        .WithMany(c => c.Vendors)
                        .HasForeignKey(c => c.CompanyGuid)
                        .OnDelete(DeleteBehavior.Restrict);

            // Many Vendors with Many Projects (N:N)
            modelBuilder.Entity<Vendor>()
                        .HasMany(v => v.Projects)
                        .WithMany(p => p.Vendors)
                        .UsingEntity(j => j.ToTable("tb_tr_vendor_project"));

            // Many VendorApprovals with One User (N:1)
            modelBuilder.Entity<VendorApproval>()
                        .HasOne(va => va.User)
                        .WithMany(u => u.VendorApprovals)
                        .HasForeignKey(u => u.ApprovedByUserGuid)
                        .OnDelete(DeleteBehavior.Restrict);

            // Many VendorApprovals with One Vendor (N:1)
            modelBuilder.Entity<VendorApproval>()
                        .HasOne(va => va.Vendor)
                        .WithMany(v => v.VendorApprovals)
                        .HasForeignKey(v => v.VendorGuid)
                        .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
