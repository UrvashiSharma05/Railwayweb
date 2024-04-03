using System.ComponentModel.DataAnnotations;

namespace Railwayweb.Models.Railway
{
    public class Price
    {
        [Key]
        public int Id { get; set; }
        public string? name { get; set; }
        public Seat Seat { get; set; }
    }
}
