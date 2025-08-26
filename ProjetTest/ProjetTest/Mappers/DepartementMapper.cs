using ProjetTest.Dto;
using ProjetTest.Models;

namespace ProjetTest.Mappers
{
    public class DepartementMapper
    {
        public static Departement toDepartementDto(DepartementDto dto)
        {
            if (dto == null)
            {
                return null;
            }
            Departement departement = new Departement();
            departement.code = dto.Code;
            departement.name = dto.Name;
            return departement;
        }
    }
}
