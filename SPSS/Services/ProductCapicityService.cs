
using System.Collections.Generic;
using SPSS.Entities;
using SPSS.Repositories.GenericRepository;

public class ProductCapicityService
{
    private readonly IGenericRepository<ProductCapicity> _repository;

    public ProductCapicityService(IGenericRepository<ProductCapicity> repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<ProductCapicity>> GetAllAsync() => await _repository.GetAllAsync();
    public async Task<ProductCapicity> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);
    public async Task AddAsync(ProductCapicity entity) => _repository.AddAsync(entity);
    public async Task UpdateAsync(ProductCapicity entity) => _repository.UpdateAsync(entity);
    public async Task DeleteAsync(ProductCapicity entity) => _repository.DeleteAsync(entity);
}