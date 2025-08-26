using ProjetTest.Dto;
using ProjetTest.Models;

namespace ProjetTest.Mappers
{
    public class EmployeMapper
    {
        public static Employe EmployeDTOtoEmployee(EmployeDto dto)
        {
            if (dto == null)
            {
                return null;
            }
            Employe employe= new Employe();
            employe.firstName= dto.firstName;
            employe.lastName= dto.lastName;
            employe.email= dto.email;
            employe.phone= dto.phone;
            employe.hiringDate = dto.hiringDate ?? DateTime.Now;
            employe.DepartementId = dto.DepartementId;
            employe.password = BCrypt.Net.BCrypt.HashPassword(dto.password);

            return employe;
        }
    }
}
