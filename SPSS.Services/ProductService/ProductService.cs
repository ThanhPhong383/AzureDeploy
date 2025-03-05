
using System.Collections.Generic;
using SPSS.Entities;
using SPSS.Repositories.GenericRepository;
using SPSS.Services.FirebaseStorageService;
using SPSS.Services.ProductService;

public class ProductService (IGenericRepository<Product> repository) : IProductService
{
    public async Task<IEnumerable<Product>> GetAllAsync() => await repository.GetAllAsync();
    public async Task<Product> GetByIdAsync(int id) => await repository.GetByIdAsync(id);
    public async Task AddAsync(Product entity) => await repository.AddAsync(entity);
    public async Task UpdateAsync(Product entity) => await repository.UpdateAsync(entity);
    public async Task DeleteAsync(Product entity) => await repository.DeleteAsync(entity);

}