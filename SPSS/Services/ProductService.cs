
using System.Collections.Generic;
using SPSS.Entities;
using SPSS.Repositories.GenericRepository;

public class ProductService (IGenericRepository<Product> repository)
{
    public async Task<IEnumerable<Product>> GetAllAsync() => await repository.GetAllAsync();
    public async Task<Product> GetByIdAsync(int id) => await repository.GetByIdAsync(id);
    public async Task AddAsync(Product entity) => repository.AddAsync(entity);
    public async Task UpdateAsync(Product entity) => repository.UpdateAsync(entity);
    public async Task DeleteAsync(Product entity) => repository.DeleteAsync(entity);
}