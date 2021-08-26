using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TribalWarsHubBackEnd.Models
{
    public interface ITribeODRepository
    {
        TribeOD GetById(int world, int tribe_id);
        IEnumerable<TribeOD> GetAll();
        void Add(TribeOD tribeOD);
        void Delete(TribeOD tribeOD);
        void Update(TribeOD tribeOD);
        void SaveChanges();
    }
}
