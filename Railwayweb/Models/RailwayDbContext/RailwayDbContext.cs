using Microsoft.EntityFrameworkCore;
using Railwayweb.Models.Railway;

namespace Railwayweb.Models.RailwayDbContext
{
	public class RailwayDbContext :DbContext
	{
		public RailwayDbContext(DbContextOptions options) : base(options)
		{

		}
		public DbSet<Loginform> loginforms { get; set; }
		public DbSet<Regisform> regisforms { get; set; }
		public DbSet<From> froms { get; set; }
		public DbSet<To> tos { get; set; }
		public DbSet<TrainName> trainnames { get; set; }
        public DbSet<Seat> seats { get; set; }
        public DbSet<Price> prices { get; set; }
        public DbSet<Bookingform> bookingforms { get; set; }

      


    }
}
