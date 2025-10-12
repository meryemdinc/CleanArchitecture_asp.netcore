using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
namespace App.Repositories
{
    public class GenericRepository<T>(AppDbContext context) : IGenericRepository<T> where T : class
    {
        protected AppDbContext Context = context;//protected miras alınan classlarda kullanılır.
        private readonly DbSet<T> _dbSet=context.Set<T>();//readonlyde sadece 1 kere set edebilirsin,değer atayabilirsin.
        public IQueryable<T> GetAll()=> _dbSet.AsQueryable().AsNoTracking();//memory i şişirmemek için asnotracking
        public IQueryable<T> Where(Expression<Func<T, bool>> predicate)=> _dbSet.Where(predicate).AsQueryable().AsNoTracking();
        public ValueTask<T?> GetByIdAsync(int id) => _dbSet.FindAsync(id);   
        public async ValueTask AddAsync(T entity) => await _dbSet.AddAsync(entity);
        public void Update(T entity) => _dbSet.Update(entity);
        public void Delete(T entity)=>_dbSet.Remove(entity);

        //AsNoTracking() veri üzerinde değişiklik yapılmayacaksa sadece veriyi çekeceksen performans açısından faydalıdır.
    }
}
