using Domain.Entities;

namespace Data.Interfaces
{
    public interface IGenericRepo<TSource> where TSource : Auditable
    {
        List<TSource> GetAll();
        TSource? GetById(int id);
        TSource Update(int id, TSource source);
        TSource Create(TSource source);
        bool Delete(int id);
    }
}
