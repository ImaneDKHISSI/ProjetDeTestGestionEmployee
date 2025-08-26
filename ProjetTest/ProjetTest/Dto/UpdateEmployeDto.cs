using System.ComponentModel.DataAnnotations;

namespace ProjetTest.Dto
{
    public class UpdateEmployeDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Le nom de famille est obligatoire.")]
        [StringLength(50, ErrorMessage = "Le nom de famille ne peut pas dépasser 50 caractères.")]
        public string lastName { get; set; }
        [Required(ErrorMessage = "Le prénom est obligatoire.")]
        [StringLength(50, ErrorMessage = "Le prénom ne peut pas dépasser 50 caractères.")]
        public string firstName { get; set; }
        [Required(ErrorMessage = "L'email est obligatoire.")]
        [EmailAddress(ErrorMessage = "Format d'email invalide.")]
        public string email { get; set; }
        [Phone(ErrorMessage = "Numéro de téléphone invalide.")]
        [StringLength(15, ErrorMessage = "Le numéro de téléphone ne peut pas dépasser 15 caractères.")]
        public string phone { get; set; }
        public DateTime? hiringDate { get; set; }
    }
}
