
using System.Collections.Generic;
using SPSS.Entities;
using SPSS.Repositories.GenericRepository;

public class RoutinesProductListService (IGenericRepository<RoutinesProductList> repository)
{
    public async Task<IEnumerable<RoutinesProductList>> GetAllAsync() => await repository.GetAllAsync();
    public async Task<RoutinesProductList> GetByIdAsync(int id) => await repository.GetByIdAsync(id);
    public async Task AddAsync(RoutinesProductList entity) => await repository.AddAsync(entity);
    public async Task UpdateAsync(RoutinesProductList entity) => await repository.UpdateAsync(entity);
    public async Task DeleteAsync(RoutinesProductList entity) => await repository.DeleteAsync(entity);
}