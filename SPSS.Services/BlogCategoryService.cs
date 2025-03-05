
using System.Collections.Generic;
using SPSS.Entities;
using SPSS.Repositories.GenericRepository;

public class BlogCategoryService (IGenericRepository<BlogCategory> repository)
{
    public async Task<IEnumerable<BlogCategory>> GetAllAsync() => await repository.GetAllAsync();
    public async Task<BlogCategory> GetByIdAsync(int id) => await repository.GetByIdAsync(id);
    public async Task AddAsync(BlogCategory entity) => await repository.AddAsync(entity);
    public async Task UpdateAsync(BlogCategory entity) => await repository.UpdateAsync(entity);
    public async Task DeleteAsync(BlogCategory entity) => await repository.DeleteAsync(entity);
}