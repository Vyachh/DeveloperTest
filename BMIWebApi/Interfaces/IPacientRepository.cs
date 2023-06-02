using BMIWebApi.Dto;
using BMIWebApi.Models;

namespace BMIWebApi.Interfaces
{
    public interface IPacientRepository
    {
        ICollection<Pacient> GetPacients();
        Pacient GetPacient(string nickName);
        Pacient GetPacientTrimToUpper(PacientDto pacientDto);
        bool Add(Pacient pacient);
        bool Update(Pacient pacient);
        bool Delete(string nickName);
        bool Save();
    }
}
