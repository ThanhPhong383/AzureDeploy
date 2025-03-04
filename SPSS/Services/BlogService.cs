
using System.Collections.Generic;
using SPSS.Entities;
using SPSS.Repositories.GenericRepository;

public class BlogService (IGenericRepository<Blog> repository)
{
    public async Task<IEnumerable<Blog>> GetAllAsync() => await repository.GetAllAsync();
    public async Task<Blog> GetByIdAsync(int id) => await repository.GetByIdAsync(id);
    public async Task AddAsync(Blog entity) => repository.AddAsync(entity);
    public async Task UpdateAsync(Blog entity) => repository.UpdateAsync(entity);
    public async Task DeleteAsync(Blog entity) => repository.DeleteAsync(entity);
}