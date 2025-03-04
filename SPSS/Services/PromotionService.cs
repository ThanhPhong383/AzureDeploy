
using System.Collections.Generic;
using SPSS.Entities;
using SPSS.Repositories.GenericRepository;

public class PromotionService (IGenericRepository<Promotion> repository)
{
    public async Task<IEnumerable<Promotion>> GetAllAsync() => await repository.GetAllAsync();
    public async Task<Promotion> GetByIdAsync(int id) => await repository.GetByIdAsync(id);
    public async Task AddAsync(Promotion entity) => await repository.AddAsync(entity);
    public async Task UpdateAsync(Promotion entity) => await repository.UpdateAsync(entity);
    public async Task DeleteAsync(Promotion entity) => await repository.DeleteAsync(entity);
}