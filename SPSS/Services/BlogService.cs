
using System.Collections.Generic;
using SPSS.Entities;
using SPSS.Repositories.GenericRepository;

public class BlogService
{
    private readonly IGenericRepository<Blog> _repository;

    public BlogService(IGenericRepository<Blog> repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Blog>> GetAllAsync() => await _repository.GetAllAsync();
    public async Task<Blog> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);
    public async Task AddAsync(Blog entity) => _repository.AddAsync(entity);
    public async Task UpdateAsync(Blog entity) => _repository.UpdateAsync(entity);
    public async Task DeleteAsync(Blog entity) => _repository.DeleteAsync(entity);
}