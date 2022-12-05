namespace TestPossumus.UnitOfWork.Repository
{
    public interface IRepository<T>
    {
        public Task<List<T>> GetAll();

        public Task<T> GetById(int Id);

        public Task<T> Add(T record);

        public void Delete(T record);

        public void Update(T record);
    }
}
