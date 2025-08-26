using ProjetTest.Dto;
using ProjetTest.Models;

namespace ProjetTest.Services.Interfaces
{
    public interface IEmployeService
    {
        Task<IEnumerable<Employe>> GetEmployes();
        Task<Employe> GetEmploye(int id);
        Task<Employe> AddEmploye(EmployeDto dto);
        Task<Employe> UpdateEmploye(UpdateEmployeDto employe);
        Task<bool> DeleteEmploye(int id);
        Task<IEnumerable<Employe>> Rechercher(string searchText);
    }
}
