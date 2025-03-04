
using System.Collections.Generic;
using SPSS.Entities;
using SPSS.Repositories.GenericRepository;

public class ProductService
{
    private readonly IGenericRepository<Product> _repository;

    public ProductService(IGenericRepository<Product> repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Product>> GetAllAsync() => await _repository.GetAllAsync();
    public async Task<Product> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);
    public async Task AddAsync(Product entity) => _repository.AddAsync(entity);
    public async Task UpdateAsync(Product entity) => _repository.UpdateAsync(entity);
    public async Task DeleteAsync(Product entity) => _repository.DeleteAsync(entity);
}