using System;
using System.ComponentModel.DataAnnotations;

namespace Hotel.Models
{
    public class Guest
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Fornavn er påkrevd.")]
        [StringLength(50, ErrorMessage = "Fornavn kan ikke være mer enn 50 tegn.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Etternavn er påkrevd.")]
        [StringLength(50, ErrorMessage = "Etternavn kan ikke være mer enn 50 tegn.")]
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Fødselsdato er påkrevd.")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }

        [EmailAddress(ErrorMessage = "Ugyldig e-postformat.")]
        [Required(ErrorMessage = "Email er påkrevd.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Mobilnummer er påkrevd.")]
        [Phone(ErrorMessage = "Ugyldig mobilnummer.")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Land er påkrevd.")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Passord er påkrevd.")]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Passord må være minimum 6 tegn.")]
        public string Password { get; set; }
    }
}
