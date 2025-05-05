using System.ComponentModel.DataAnnotations;

namespace Hotel.Models
{
    public class Guest
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        public string Email { get; set; }
        public string Phone { get; set; }
        public String Country { get; set; }
        public string Password { get; set; }

    }
}
