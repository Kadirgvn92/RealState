using System.Linq.Expressions;

namespace RealState.Repository.IRepository;

public interface IRepository<T> where T : class
{
    void Insert(T t);
    void Update(T t);
    void Delete(int id);
    T GetByID(int id);
    List<T> GetAll();
}
