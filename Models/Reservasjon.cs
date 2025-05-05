using System.ComponentModel.DataAnnotations;

namespace Hotel.Models
{
    public class Reservasjon
    {
        [Key] public int ReservasjonsId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime endDate { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }
    }
}
