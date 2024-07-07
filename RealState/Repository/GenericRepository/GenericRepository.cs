using RealState.Context;
using RealState.Repository.IRepository;
using System.Linq.Expressions;

namespace RealState.Repository.GenericRepository;

public class GenericRepository<T> : IRepository<T> where T : class
{
    private readonly RealStateContext _db;

    public GenericRepository(RealStateContext db)
    {
        _db = db;
    }
    public void Delete(int id)
    {

        var values = _db.Set<T>().Find(id);
        if (values != null)
        {
            _db.Set<T>().Remove(values);
            _db.SaveChanges();
        }
    }

    public List<T> GetAll()
    {
        var values = _db.Set<T>().ToList();
        return values;
    }

    public T GetByID(int id)
    {
        var values = _db.Set<T>().Find(id);
        return values;
    }

    public void Insert(T t)
    {
        _db.Set<T>().Add(t);
        _db.SaveChanges();
    }

    public void Update(T t)
    {
        _db.Set<T>().Update(t);
        _db.SaveChanges();
    }
}
