
using System.Collections.Generic;
using SPSS.Entities;
using SPSS.Repositories.GenericRepository;

public class BlogCategoryService
{
    private readonly IGenericRepository<BlogCategory> _repository;

    public BlogCategoryService(IGenericRepository<BlogCategory> repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<BlogCategory>> GetAllAsync() => await _repository.GetAllAsync();
    public async Task<BlogCategory> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);
    public async Task AddAsync(BlogCategory entity) => _repository.AddAsync(entity);
    public async Task UpdateAsync(BlogCategory entity) => _repository.UpdateAsync(entity);
    public async Task DeleteAsync(BlogCategory entity) => _repository.DeleteAsync(entity);
}