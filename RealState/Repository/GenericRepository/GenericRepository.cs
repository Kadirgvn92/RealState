using Microsoft.EntityFrameworkCore;
using RealState.Repository.IRepository;

public class GenericRepository<T> : IRepository<T> where T : class
{
    protected readonly DbContext _context;
    private readonly DbSet<T> _dbSet;

    public GenericRepository(DbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public void Insert(T entity)
    {
        _dbSet.Add(entity);
        _context.SaveChanges();
    }

    public void Update(T entity)
    {
        _dbSet.Attach(entity);
        _context.Entry(entity).State = EntityState.Modified;
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var entity = _dbSet.Find(id);
        if (entity != null)
        {
            var softDeletable = entity as ISoftDeletable;
            if (softDeletable != null)
            {
                softDeletable.IsDeleted = true;
                Update(entity);
            }
            else
            {
                _dbSet.Remove(entity);
                _context.SaveChanges();
            }
        }
    }

    public T GetByID(int id)
    {
        return _dbSet.Find(id);
    }

    public List<T> GetAll()
    {
        return _dbSet.Where(e => !(e as ISoftDeletable).IsDeleted).ToList();
    }

    public List<T> GetAllIncludingDeleted()
    {
        return _dbSet.ToList();
    }
}
