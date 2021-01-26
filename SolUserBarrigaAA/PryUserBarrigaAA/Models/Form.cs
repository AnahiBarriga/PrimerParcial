namespace PryUserBarrigaAA.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Form
    {
        [Key]
        public int PersonId { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Nombre debe contener de 5 a 100 caracteres", MinimumLength = 5)]
        public string Name { get; set; }
        [Required]
        public string Username { get; set; }
        [EmailAddressAttribute]
        public string Email { get; set; }
        public string Adress { get; set; }
        public string Street { get; set; }
        public int CellPhoneNumber { get; set; }
        public string City { get; set; }


    }
}