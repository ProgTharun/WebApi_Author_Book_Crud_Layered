namespace WebApi_Author_Book_Example.Repository
{
    public interface IGenericRepository<T>
    {
        public int Add(T entity);
        public T Update(T entity);
        public bool Delete(T entity);
        public T GetByid(int id);
        public IQueryable<T> GetAll();
      
    }
}
