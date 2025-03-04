
using System.Collections.Generic;
using SPSS.Entities;
using SPSS.Repositories.GenericRepository;

public class ProductCapicityService (IGenericRepository<ProductCapicity> repository)
{
    public async Task<IEnumerable<ProductCapicity>> GetAllAsync() => await repository.GetAllAsync();
    public async Task<ProductCapicity> GetByIdAsync(int id) => await repository.GetByIdAsync(id);
    public async Task AddAsync(ProductCapicity entity) => await repository.AddAsync(entity);
    public async Task UpdateAsync(ProductCapicity entity) => await repository.UpdateAsync(entity);
    public async Task DeleteAsync(ProductCapicity entity) => await repository.DeleteAsync(entity);
}