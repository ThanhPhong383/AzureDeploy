
using System.Collections.Generic;
using SPSS.Entities;
using SPSS.Repositories.GenericRepository;

public class SkinTypeService (IGenericRepository<SkinType> repository)
{
    public async Task<IEnumerable<SkinType>> GetAllAsync() => await repository.GetAllAsync();
    public async Task<SkinType> GetByIdAsync(int id) => await repository.GetByIdAsync(id);
    public async Task AddAsync(SkinType entity) => await repository.AddAsync(entity);
    public async Task UpdateAsync(SkinType entity) => await repository.UpdateAsync(entity);
    public async Task DeleteAsync(SkinType entity) => await repository.DeleteAsync(entity);
}