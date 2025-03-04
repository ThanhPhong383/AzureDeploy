
using System.Collections.Generic;
using SPSS.Entities;
using SPSS.Repositories.GenericRepository;

public class BrandService (IGenericRepository<Brand> repository)
{
    public async Task<IEnumerable<Brand>> GetAllAsync() => await repository.GetAllAsync();
    public async Task<Brand> GetByIdAsync(int id) => await repository.GetByIdAsync(id);
    public async Task AddAsync(Brand entity) => repository.AddAsync(entity);
    public async Task UpdateAsync(Brand entity) => repository.UpdateAsync(entity);
    public async Task DeleteAsync(Brand entity) => repository.DeleteAsync(entity);
}