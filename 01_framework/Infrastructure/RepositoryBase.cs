using System.Linq.Expressions;
using _01_framework.Domain;
using Microsoft.EntityFrameworkCore;

namespace _01_framework.Infrastructure
{
    public class RepositoryBase<TKey,T>:IRepository<TKey,T> where T : class
    {
        private readonly DbContext _context;

        public RepositoryBase(DbContext context)
        {
            _context = context;
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetBy(TKey id)
        {
            return _context.Find<T>(id);
        }

        public void Create(T entity)
        {
            _context.Add<T>(entity);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public bool IsExist(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Any(expression);
        }

        public async Task<T>? GetByAsync(TKey id) => await _context.Set<T>().FindAsync(id);


        public async Task<T>? FirstOfDefault(Expression<Func<T, bool>> predicate) =>
            await _context.Set<T>().FirstOrDefaultAsync(predicate);


        public async Task CreateAsync(T entity)=> await _context.AddAsync(entity);
         
        public async Task<List<T>> GetAllAsync()=> await _context.Set<T>().AsNoTracking().ToListAsync();
      

        public async Task<List<T>> GetWhere(Expression<Func<T, bool>> predicate) =>
        await _context.Set<T>().Where(predicate).AsNoTracking().ToListAsync();
       

        public async Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate) =>
      await _context.Set<T>().AsNoTracking().AnyAsync(predicate);
     

        public async Task SaveChangesAsync()=> await _context.SaveChangesAsync();
      
    }
}
