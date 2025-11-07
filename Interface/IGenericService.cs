namespace LibraryStudio.Interface;

public interface IGenericService<T> where T : class
{
    List<T> GetAllAsync();

    T? GetById(int id);

    void Add(T entity);

    void Update(T entity);

    void Delete(T entity);

    void DeleteAll();

    void DeleteById(int id);
}
