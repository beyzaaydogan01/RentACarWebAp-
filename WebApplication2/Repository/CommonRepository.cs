using WebApplication2.Models;
using static System.Reflection.Metadata.BlobBuilder;

namespace WebApplication2.Repository
{
    public abstract class CommonRepository<T>
    {
        public abstract T GetById(int id);
        public abstract List<T> GetAll();
        public abstract T Add(T created);
        public abstract T Update(T updated);
        public abstract T Remove(int id);
    }
}
