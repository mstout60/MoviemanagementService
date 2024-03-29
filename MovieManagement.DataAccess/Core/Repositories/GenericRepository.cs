﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MovieManagement.DataAccess;
using SQLitePCL;

namespace MovieManagement.Domain;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    protected MovieManagementDbContext _context;
    protected DbSet<T> dbSet;
    protected readonly ILogger _logger;

    public GenericRepository(
        MovieManagementDbContext context,
        ILogger logger
    )
    {
        _context = context;
        _logger = logger;

        this.dbSet = context.Set<T>();
    }

    public virtual async Task<bool> Add(T entity)
    {
        await dbSet.AddAsync(entity);
        return true;
    }

    public virtual async Task<IEnumerable<T>> All()
    {
        return await dbSet.ToListAsync();
    }

    public virtual Task<bool> Delete(Guid id)
    {
        throw new NotImplementedException();
    }

    public virtual async Task<T> GetById(Guid id)
    {
        return await dbSet.FindAsync(id);
    }

    public virtual Task<bool> Upsert(T entity)
    {
        throw new NotImplementedException();
    }
    //protected DbSet<T> dbSet;
}
