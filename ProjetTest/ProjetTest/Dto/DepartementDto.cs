using System.ComponentModel.DataAnnotations;

namespace ProjetTest.Dto
{
    public class DepartementDto
    {
        [Required(ErrorMessage = "Le nom du département est obligatoire.")]
        [StringLength(100, ErrorMessage = "Le nom ne peut pas dépasser 100 caractères.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Le code du département est obligatoire.")]
        [StringLength(10, ErrorMessage = "Le code ne peut pas dépasser 10 caractères.")]
        public string Code { get; set; }
        public List<EmployeDto> Employes { get; set; }
    }
}
