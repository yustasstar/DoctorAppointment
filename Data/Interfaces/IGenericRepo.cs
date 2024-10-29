using Domain.Entities;

namespace Data.Interfaces
{
    public interface IGenericRepo<TSource> where TSource : Auditable
    {
        TSource Create(TSource source);
        TSource? GetById(int id);
        TSource Update(int id, TSource source);
        IEnumerable<TSource> GetAll();
        bool Delete(int id);
    }
}
