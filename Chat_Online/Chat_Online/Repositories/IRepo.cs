namespace Chat_Online.Repositories
{
    public interface IRepo <T>
    {
        T? GetById(int id);
        T? GetByCode(string code);
        List<T> GetAll();
        bool Insert(T item);
        bool Update(T item);
        bool SoftDelete(string code);
    }
}
