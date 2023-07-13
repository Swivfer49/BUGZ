namespace BUGZ.LAYER_DATACCESS
{
    public interface IRepository<T>
    {
        public T Get(params object[] keys);
        public IEnumerable<T> GetAll();
        public void Insert(T item);
        public void Update(T item);
        public void Delete(T item);
    }
}
