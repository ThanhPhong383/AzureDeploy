
using System.Collections.Generic;
using SPSS.Entities;
using SPSS.Repositories.GenericRepository;

public class CategoryService (IGenericRepository<Category> repository)
{
    public async Task<IEnumerable<Category>> GetAllAsync() => await repository.GetAllAsync();
    public async Task<Category> GetByIdAsync(int id) => await repository.GetByIdAsync(id);
    public async Task AddAsync(Category entity) => repository.AddAsync(entity);
    public async Task UpdateAsync(Category entity) => repository.UpdateAsync(entity);
    public async Task DeleteAsync(Category entity) => repository.DeleteAsync(entity);
}