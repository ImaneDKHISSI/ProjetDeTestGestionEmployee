using Microsoft.EntityFrameworkCore;
using ProjetTest.Data;
using ProjetTest.Dto;
using ProjetTest.Mappers;
using ProjetTest.Models;
using ProjetTest.Services.Interfaces;

namespace ProjetTest.Services.Implementations
{
    public class EmployeService :IEmployeService
    {
        private readonly MyContext db;
        public EmployeService(MyContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<Employe>> GetEmployes()
        {
            return await db.Employes.ToListAsync();

        }
        public async Task<Employe> AddEmploye(EmployeDto dto)
        {
            var employe = EmployeMapper.EmployeDTOtoEmployee(dto);
            db.Employes.Add(employe);
            await db.SaveChangesAsync();
            return employe;
        }

        public async Task<Employe> GetEmploye(int id)
        {
            return await db.Employes.FindAsync(id);
        }
        public async Task<bool> DeleteEmploye(int id)
        {
            var employe = await db.Employes.FindAsync(id);
            if (employe == null)
            {
                return false;
            }
            db.Employes.Remove(employe);
            db.SaveChanges();
            return true;

        }
        public async Task<Employe> UpdateEmploye(UpdateEmployeDto dto)
        {
            if (dto.Id==null)
            {
                return null;
            }
            
            // Récupérer l'employé existant
            var employe = await db.Employes.FindAsync(dto.Id);
            if (employe == null)
            {
                return null;
            }
            employe.lastName = dto.lastName;
            employe.firstName = dto.firstName;
            employe.email = dto.email;
            employe.phone = dto.phone;
            employe.hiringDate = dto.hiringDate;
            db.Entry(employe).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return employe;
        }
        public async Task<IEnumerable<Employe>> Rechercher(string searchText)
        {
            var query = db.Employes.AsNoTracking().AsQueryable(); //transforme la collection en une requette LINQ, 
            //permet de contruire dynamiquement des conditions de filtrage
            if (!string.IsNullOrEmpty(searchText))//verifier que searchText n'est pas vide et n'est pas null
            {
                searchText = searchText.ToLower(); //rendre le text fournie en miniscule
                query = query.Where(m => m.firstName.ToLower().Contains(searchText)); //verifier est ce que le Libelle contient le texte rechercher
            }
            return await query.ToListAsync();
        }

      
    }
}
