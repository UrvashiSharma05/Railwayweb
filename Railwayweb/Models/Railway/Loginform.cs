using System.ComponentModel.DataAnnotations;

namespace Railwayweb.Models.Railway
{
	public class Loginform
	{
		[Key]
		public int LId { get; set; }

		public string Email{ get; set; }
		public string Password { get; set; }
		public string Cpassword { get; set; }
		public Regisform Regisform { get; set; }

	}
}
