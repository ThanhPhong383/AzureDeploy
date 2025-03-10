
using System.Collections.Generic;
using SPSS.Entities;
using SPSS.Repositories.GenericRepository;

public class CityService (IGenericRepository<City> repository)
{
    public async Task<IEnumerable<City>> GetAllAsync() => await repository.GetAllAsync();
    public async Task<City> GetByIdAsync(int id) => await repository.GetByIdAsync(id);
    public async Task AddAsync(City entity) => await repository.AddAsync(entity);
    public async Task UpdateAsync(City entity) => await repository.UpdateAsync(entity);
    public async Task DeleteAsync(City entity) => await repository.DeleteAsync(entity);
}