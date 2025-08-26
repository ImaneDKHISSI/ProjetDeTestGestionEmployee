using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetTest.Models
{
    [Table("Employe")]
    public class Employe
    {
        public int Id { get; set; }
        public string lastName { get; set; }
        public string firstName { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string phone { get; set; }
        public DateTime? hiringDate { get; set; }
        public int DepartementId { get; set; }
        public Departement? Departement { get; set; }

    }
}
