
using System.Collections.Generic;
using SPSS.Entities;
using SPSS.Repositories.GenericRepository;

public class CategoryService
{
    private readonly IGenericRepository<Category> _repository;

    public CategoryService(IGenericRepository<Category> repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Category>> GetAllAsync() => await _repository.GetAllAsync();
    public async Task<Category> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);
    public async Task AddAsync(Category entity) => _repository.AddAsync(entity);
    public async Task UpdateAsync(Category entity) => _repository.UpdateAsync(entity);
    public async Task DeleteAsync(Category entity) => _repository.DeleteAsync(entity);
}