
using System.Collections.Generic;
using SPSS.Entities;
using SPSS.Repositories.GenericRepository;

public class BrandService
{
    private readonly IGenericRepository<Brand> _repository;

    public BrandService(IGenericRepository<Brand> repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Brand>> GetAllAsync() => await _repository.GetAllAsync();
    public async Task<Brand> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);
    public async Task AddAsync(Brand entity) => _repository.AddAsync(entity);
    public async Task UpdateAsync(Brand entity) => _repository.UpdateAsync(entity);
    public async Task DeleteAsync(Brand entity) => _repository.DeleteAsync(entity);
}