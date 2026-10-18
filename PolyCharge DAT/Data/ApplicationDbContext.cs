using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PolyCharge_DAT.Models;

namespace PolyCharge_DAT.Data
{
	public class ApplicationDbContext : IdentityDbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}

		public DbSet<Run> Runs { get; set; }
        public DbSet<PRDCTest> PRDCTests { get; set; }
        public DbSet<PODCTest> PODCTests { get; set; }
        public DbSet<POBITest> POBITests { get; set; }
        public DbSet<Issue> Issues { get; set; }
    }
}