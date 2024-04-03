using System.ComponentModel.DataAnnotations;

namespace Railwayweb.Models.Railway
{
	public class Bookingform
	{
		[Key]
		public int PId { get; set; }
		
		public string Email { get; set; }
		public long Phoneno { get; set; }

        public string? BName { get; set; }

        public int Age { get; set; }

        public string? Gender { get; set; }

        public string? Berth { get; set; }

        public int Amount { get; set; }
        public long CardNumber { get; set; }
		public string? CardName { get; set; }
		public int CMonth { get; set; }
		public int CYear { get; set; }
		public int Cvno { get; set; }
	}
}
