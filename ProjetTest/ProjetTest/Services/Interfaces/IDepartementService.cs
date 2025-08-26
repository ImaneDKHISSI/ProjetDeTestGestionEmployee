using ProjetTest.Dto;
using ProjetTest.Models;

namespace ProjetTest.Services.Interfaces
{
    public interface IDepartementService
    {
        Task<IEnumerable<Departement>> GetDepartements();
        Task<Departement> GetDepartement(int id);
        Task<Departement> AddDepartement(DepartementDto dto);
        Task<Departement> UpdateDepartement(int id, Departement departement);
        Task<bool> DeleteDepartement(int id);
        Task<IEnumerable<Departement>> Rechercher(string searchText);
    }
}
