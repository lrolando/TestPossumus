using Microsoft.EntityFrameworkCore;

namespace TestPossumus.UnitOfWork.Repository
{
    public class CandidatoRepository : IRepository<Candidato>
    {


        private readonly ApiBDContext _Api_DBContext;

        public CandidatoRepository(ApiBDContext Api_DBContext)
        {

            _Api_DBContext = Api_DBContext;

        }

        public async Task<List<Candidato>> GetAll()
        {
            List<Candidato> ListTI;

            try
            {
                ListTI = await (from a in _Api_DBContext.Candidatos
                                select a).ToListAsync();
                Logger.Log("Se ejecuto GetAll-Candidatos");
            }
            catch (Exception ex)
            {
                Logger.Log(ex.Message);
                throw;
            }

            return ListTI;
        }

        public async Task<Candidato> GetById(int Id)
        {
            Candidato cand;

            try
            {
                cand = await (from a in _Api_DBContext.Candidatos
                              where a.Id == Id
                              select a).FirstAsync();

                Logger.Log("Se ejecuto GetById-Candidatos");
            }
            catch (Exception ex)
            {
                Logger.Log(ex.Message);
                throw;
            }

            return cand;
        }

        public async Task<Candidato> Add(Candidato newItem)
        {

            try
            {
                _Api_DBContext.Candidatos.Add(newItem);
                _Api_DBContext.SaveChanges();

                Logger.Log("Se ejecuto Add-Candidatos");
            }
            catch (Exception ex)
            {
                Logger.Log(ex.Message);
                throw;
            }

            return newItem;
        }


        public void Update(Candidato Item)
        {

            try
            {
                _Api_DBContext.Candidatos.Update(Item);
                _Api_DBContext.SaveChanges();

                Logger.Log("Se ejecuto Update-Candidatos");
            }
            catch (Exception ex)
            {
                Logger.Log(ex.Message);
                throw;
            }
        }

        public void Delete(Candidato candidato)
        {

            try
            {
                _Api_DBContext.Candidatos.Remove(candidato);
                _Api_DBContext.SaveChanges();

                Logger.Log("Se ejecuto Delete-Candidatos");
            }
            catch (Exception ex)
            {
                Logger.Log(ex.Message);
                throw;
            }
        }
    }
}
