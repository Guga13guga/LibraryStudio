using LibraryStudio.Database;
using LibraryStudio.Interface;
using Microsoft.EntityFrameworkCore;

namespace LibraryStudio.Services;

public class GenericService<T> :IGenericService<T> where T : class
{
    protected readonly LibraryDbContext _context;
    private readonly DbSet<T> _dbSet;

    public GenericService(LibraryDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public List<T> GetAllAsync()
    {
        return _dbSet.ToList();
    }

    public T? GetById(int id)
    {
        return _dbSet.Find(id);
    }

    public void Add(T entity)
    {
        _dbSet.Add(entity);
        _context.SaveChanges();
    }

    public void Update(T entity)
    {
        _dbSet.Update(entity);
        _context.SaveChanges();
    }

    public void Delete(T entity)
    {
        _dbSet.Remove(entity);
        _context.SaveChanges();
    }

    public void DeleteAll()
    {
        _dbSet.RemoveRange(_dbSet);
        _context.SaveChanges();
    }

    public void DeleteById(int id)
    {
        var entity = GetById(id);
        if (entity != null)
        {
            Delete(entity);
        }
    }
}
