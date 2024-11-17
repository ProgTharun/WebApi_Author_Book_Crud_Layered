
using Microsoft.EntityFrameworkCore;
using WebApi_Author_Book_Example.Data;

namespace WebApi_Author_Book_Example.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class

    {
        private readonly Context _context;
        private readonly DbSet<T> _table;
        public GenericRepository(Context context)
        {
            _context = context;
            _table = _context.Set<T>();

            
        }
        public int Add(T entity)
        {
            _table.Add(entity);
            return _context.SaveChanges();
        }

        public bool Delete(T entity)
        {
           _table.Remove(entity);
            _context.SaveChanges();
            return true;
        }

        public IQueryable<T> GetAll()
        {
            return _table.AsQueryable();
        }

        public T GetByid(int id)
        {
            return _table.Find(id);
        }

     

        public T Update(T entity)
        {
            _table.Update(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}
