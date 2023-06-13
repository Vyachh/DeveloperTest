using BMIWebApi.Data;
using BMIWebApi.Dto;
using BMIWebApi.Interfaces;
using BMIWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BMIWebApi.Repositories
{
    public class PacientRepository : IPacientRepository
    {
        private readonly Context context;

        public PacientRepository(Context context)
        {
            this.context = context;
        }
        public bool Add(Pacient pacient)
        {
            context.Add(pacient);
            return Save();
        }

        public bool Delete(string nickName)
        {
            context.Remove(nickName);
            return Save();
        }

        public ICollection<Pacient> GetPacients()
        {
            return context.Pacients.ToList();
        }

        public Pacient GetPacient(string nickName)
        {
            return context.Pacients
                .Include(p => p.BMIIndex)
                .FirstOrDefault(p => p.NickName == nickName);
        }

        public bool Update(Pacient pacient)
        {
            var existingPacient = context.Pacients
                .Where(p => p.NickName == pacient.NickName)
                .FirstOrDefault();
            if (existingPacient == null)
            {
                return false; // Сущность не найдена, обновление невозможно
            }

            context.Update(existingPacient);
            return Save();
        }

        public bool Save() => context.SaveChanges() > 0;

        public Pacient GetPacientTrimToUpper(PacientDto pacientDto)
        {
            return GetPacients()
                .Where(p => p.NickName.Trim().ToUpper() == pacientDto.NickName.TrimEnd().ToUpper())
                .FirstOrDefault();
        }
    }
}
