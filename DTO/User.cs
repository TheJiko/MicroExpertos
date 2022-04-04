using System;
using System.ComponentModel.DataAnnotations;

namespace DTO
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Apellido")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Direccion")]
        public string Address { get; set; }

    }
}
