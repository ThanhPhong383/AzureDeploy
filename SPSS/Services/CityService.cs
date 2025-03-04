
using System.Collections.Generic;
using SPSS.Entities;
using SPSS.Repositories.GenericRepository;

public class CityService
{
    private readonly IGenericRepository<City> _repository;

    public CityService(IGenericRepository<City> repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<City>> GetAllAsync() => await _repository.GetAllAsync();
    public async Task<City> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);
    public async Task AddAsync(City entity) => _repository.AddAsync(entity);
    public async Task UpdateAsync(City entity) => _repository.UpdateAsync(entity);
    public async Task DeleteAsync(City entity) => _repository.DeleteAsync(entity);
}