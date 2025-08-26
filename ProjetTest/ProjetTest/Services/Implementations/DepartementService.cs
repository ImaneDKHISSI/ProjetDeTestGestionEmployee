using Microsoft.EntityFrameworkCore;
using ProjetTest.Data;
using ProjetTest.Dto;
using ProjetTest.Mappers;
using ProjetTest.Models;
using ProjetTest.Services.Interfaces;

namespace ProjetTest.Services.Implementations
{
    public class DepartementService :IDepartementService
    {
        private readonly MyContext db;
        public DepartementService(MyContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<Departement>> GetDepartements()
        {
            return await db.Departements.ToListAsync();

        }
        public async Task<Departement> AddDepartement(DepartementDto dto)
        {
            var departement= DepartementMapper.toDepartementDto(dto);
            db.Departements.Add(departement);
            await db.SaveChangesAsync();
            return departement;
        }

        public async Task<Departement> GetDepartement(int id)
        {
            return await db.Departements.FindAsync(id);
        }
        public async Task<bool> DeleteDepartement(int id)
        {
            var departement = await db.Departements.FindAsync(id);
            if (departement == null)
            {
                return false;
            }
            db.Departements.Remove(departement);
            db.SaveChanges();
            return true;

        }
        public async Task<Departement> UpdateDepartement(int id, Departement departement)
        {
            if (id != departement.Id)
            {
                return null;
            }
            db.Entry(departement).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return departement;
        }
        public async Task<IEnumerable<Departement>> Rechercher(string searchText)
        {
            var query = db.Departements.AsNoTracking().AsQueryable(); //transforme la collection en une requette LINQ, 
            //permet de contruire dynamiquement des conditions de filtrage
            if (!string.IsNullOrEmpty(searchText))//verifier que searchText n'est pas vide et n'est pas null
            {
                searchText = searchText.ToLower(); //rendre le text fournie en miniscule
                query = query.Where(d => d.name.ToLower().Contains(searchText)); //verifier est ce que le Libelle contient le texte rechercher
            }
            return await query.ToListAsync();
        }

        
    }
}
