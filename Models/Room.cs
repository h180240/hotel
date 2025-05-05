using System.ComponentModel.DataAnnotations;

namespace Hotel.Models
{
    public class Room
    {
        public int Id { get; set; }
        public int NumberOfBeds { get; set; }
        public int RoomSize { get; set; }
        public String? Quality { get; set; }

        public Boolean Reserved { get; set; }
    }
}