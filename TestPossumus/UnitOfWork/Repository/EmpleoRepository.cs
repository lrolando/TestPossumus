using Microsoft.EntityFrameworkCore;

namespace TestPossumus.UnitOfWork.Repository
{
    public class EmpleoRepository : IRepository<Empleo>
    {

        private readonly ApiBDContext _Api_DBContext;

        public EmpleoRepository(ApiBDContext Api_DBContext)
        {

            _Api_DBContext = Api_DBContext;

        }

        public async Task<List<Empleo>> GetAll()
        {
            List<Empleo> ListTI = new List<Empleo>();


            try
            {
                //var b = await (from a in _Api_DBContext.Empleos
                //               join c in _Api_DBContext.Candidatos
                //               on a.Id equals c.IdEmpleo into EmplCand
                //               from pco in EmplCand.DefaultIfEmpty()
                //               select new
                //               {
                //                   Id = a.Id,
                //                   NombreEmpresa = a.NombreEmpresa,
                //                   Periodo = a.Periodo,
                //                   Candidatos = a.Candidatos
                //               }
                //                ).ToListAsync();


                //foreach (var item in b)
                //{
                //    var e = new Empleo();
                //    e.Id = item.Id;
                //    e.NombreEmpresa = item.NombreEmpresa;
                //    e.Periodo = item.Periodo;
                //    foreach (var it in item.Candidatos)
                //    {
                //        e.Candidatos.Add(it);
                //    }

                //    ListTI.Add(e);
                //}

                ListTI = await (from a in _Api_DBContext.Empleos
                                select a).ToListAsync();

                Logger.Log("Se ejecuto GetAll-Empleados");
            }
            catch (Exception ex)
            {
                Logger.Log(ex.Message);
                throw;
            }

            return ListTI;
        }

        public async Task<Empleo> GetById(int Id)
        {
            Empleo empleo = null;

            try
            {
                empleo = await (from a in _Api_DBContext.Empleos
                                where a.Id == Id
                                select a).FirstAsync();

                Logger.Log("Se ejecuto GetById-Candidatos");
            }
            catch (Exception ex)
            {
                Logger.Log(ex.Message);
                throw;
            }

            return empleo;
        }

        public async Task<Empleo> Add(Empleo newItem)
        {


            try
            {
                _Api_DBContext.Empleos.Add(newItem);
                _Api_DBContext.SaveChanges();

                Logger.Log("Se ejecuto Add-Empleos");
            }
            catch (Exception ex)
            {
                Logger.Log(ex.Message);
                throw;
            }


            return newItem;
        }


        public void Update(Empleo Item)
        {

            try
            {
                _Api_DBContext.Empleos.Update(Item);

                _Api_DBContext.SaveChanges();

                Logger.Log("Se ejecuto Update-Empleos");
            }
            catch (Exception ex)
            {
                Logger.Log(ex.Message);
                throw;
            }

        }

        public void Delete(Empleo Item)
        {

            try
            {
                _Api_DBContext.Candidatos.Remove(_Api_DBContext.Candidatos.Single(x => x.IdEmpleo == Item.Id));
                _Api_DBContext.Empleos.Remove(Item);
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
