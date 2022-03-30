using System;
using System.ComponentModel.DataAnnotations;

namespace BowlingLeague.Models
{
    public class Bowler
    {
        [Key]
        [Required]
        public int BowlerID { get; set; }

        [Required(ErrorMessage = "Enter the Bowler's First Name")]
        [MaxLength(50)]
        public string BowlerLastName { get; set; }

        [Required(ErrorMessage = "Enter the Bowler's Last Name")]
        [MaxLength(50)]
        public string BowlerFirstName { get; set; }

        [MaxLength(1)]
        public string BowlerMiddleInit { get; set; }

        [Required(ErrorMessage = "Enter the Bowler's Address")]
        [MaxLength(100)]
        public string BowlerAddress { get; set; }

        [Required(ErrorMessage = "Enter the City Associated with the Address")]
        [MaxLength(30)]
        public string BowlerCity { get; set; }

        [Required(ErrorMessage = "Select the State Associated with the Address")]
        [MaxLength(2, ErrorMessage = "Select a State from the Dropdown")]
        public string BowlerState { get; set; }

        [Required(ErrorMessage = "Enter the Zip Code Associated with the Address")]
        [MaxLength(10)]
        public string BowlerZip { get; set; }

        [Required(ErrorMessage = "Enter the Bowler's Phone Number")]
        [MaxLength(15, ErrorMessage = "Please Enter a Valid Phone Number")]
        public string BowlerPhoneNumber { get; set; }

        public int TeamID { get; set; }
        public Team Team { get; set; }
    }
}
