
using System.Collections.Generic;
using SPSS.Entities;
using SPSS.Repositories.GenericRepository;

public class ProductSkinTypeService
{
    private readonly IGenericRepository<ProductSkinType> _repository;

    public ProductSkinTypeService(IGenericRepository<ProductSkinType> repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<ProductSkinType>> GetAllAsync() => await _repository.GetAllAsync();
    public async Task<ProductSkinType> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);
    public async Task AddAsync(ProductSkinType entity) => _repository.AddAsync(entity);
    public async Task UpdateAsync(ProductSkinType entity) => _repository.UpdateAsync(entity);
    public async Task DeleteAsync(ProductSkinType entity) => _repository.DeleteAsync(entity);
}