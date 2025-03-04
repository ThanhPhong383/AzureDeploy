
using System.Collections.Generic;
using SPSS.Entities;
using SPSS.Repositories.GenericRepository;

public class SkinTypeService
{
    private readonly IGenericRepository<SkinType> _repository;

    public SkinTypeService(IGenericRepository<SkinType> repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<SkinType>> GetAllAsync() => await _repository.GetAllAsync();
    public async Task<SkinType> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);
    public async Task AddAsync(SkinType entity) => _repository.AddAsync(entity);
    public async Task UpdateAsync(SkinType entity) => _repository.UpdateAsync(entity);
    public async Task DeleteAsync(SkinType entity) => _repository.DeleteAsync(entity);
}