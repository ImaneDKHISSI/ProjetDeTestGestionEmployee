using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetTest.Models
{
    [Table("Departement")]
    public class Departement
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string code { get; set; }
        public IList<Employe>? Employes { get; set; }
    }
}
