
using System.Collections.Generic;
using SPSS.Entities;
using SPSS.Repositories.GenericRepository;

public class RoutinesProductListService
{
    private readonly IGenericRepository<RoutinesProductList> _repository;

    public RoutinesProductListService(IGenericRepository<RoutinesProductList> repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<RoutinesProductList>> GetAllAsync() => await _repository.GetAllAsync();
    public async Task<RoutinesProductList> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);
    public async Task AddAsync(RoutinesProductList entity) => _repository.AddAsync(entity);
    public async Task UpdateAsync(RoutinesProductList entity) => _repository.UpdateAsync(entity);
    public async Task DeleteAsync(RoutinesProductList entity) => _repository.DeleteAsync(entity);
}