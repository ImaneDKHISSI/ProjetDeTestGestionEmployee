using Microsoft.EntityFrameworkCore;
using ProjetTest.Models;

namespace ProjetTest.Data
{
    public class MyContext: DbContext
    {
        public DbSet<Departement> Departements { get; set; }
        public DbSet<Employe> Employes { get; set; }
        public MyContext(DbContextOptions<MyContext> opt):base(opt) { }
    }
}
