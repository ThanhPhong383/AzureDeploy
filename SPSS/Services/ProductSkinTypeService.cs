
using System.Collections.Generic;
using SPSS.Entities;
using SPSS.Repositories.GenericRepository;

public class ProductSkinTypeService (IGenericRepository<ProductSkinType> repository)
{
    public async Task<IEnumerable<ProductSkinType>> GetAllAsync() => await repository.GetAllAsync();
    public async Task<ProductSkinType> GetByIdAsync(int id) => await repository.GetByIdAsync(id);
    public async Task AddAsync(ProductSkinType entity) => await repository.AddAsync(entity);
    public async Task UpdateAsync(ProductSkinType entity) => await repository.UpdateAsync(entity);
    public async Task DeleteAsync(ProductSkinType entity) => await repository.DeleteAsync(entity);
}