using System.ComponentModel.DataAnnotations;

namespace Railwayweb.Models.Railway
{
	public class Regisform
	{
		[Key]
		public int Rid { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public long PhoneNo { get; set; }
		public DateOnly DoB {  get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public string Cpassword { get; set; }

	}
}
