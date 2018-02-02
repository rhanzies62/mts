using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Mts.Core.Entity;


namespace Mts.Infrastructure.Data
{
    public class MtsContext : DbContext
    {
        public MtsContext(DbContextOptions<MtsContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Business>().ToTable("Business");
            modelBuilder.Entity<BusinessClaim>().ToTable("BusinessClaim").HasKey(e => new { e.ClaimId, e.BusinessId });
            modelBuilder.Entity<Claim>().ToTable("Claim");
            modelBuilder.Entity<Role>().ToTable("Role");
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<UserBusiness>().ToTable("UserBusiness").HasKey(e => new { e.BusinessId, e.UserId });
            modelBuilder.Entity<UserRole>().ToTable("UserRole").HasKey(e => new { e.UserId, e.RoleId });
            modelBuilder.Entity<RoleApplicationFeature>().ToTable("RoleApplicationFeature").HasKey(e => new {e.RoleId,e.ApplicationFeatureId });
            modelBuilder.Entity<ApplicationFeature>().ToTable("ApplicationFeature");
        }

        public DbSet<Business> Businesses { get; set; }
        public DbSet<BusinessClaim> BusinessClaims { get; set; }
        public DbSet<Claim> Claims { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserBusiness> UserBusinesses { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<RoleApplicationFeature> RoleApplicationFeatures { get; set; }
        public DbSet<ApplicationFeature> ApplicationFeature { get; set; }
    }
}
