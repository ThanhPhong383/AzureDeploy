
using System.Collections.Generic;
using SPSS.Entities;
using SPSS.Repositories.GenericRepository;

public class PromotionStatusService (IGenericRepository<PromotionStatus> repository)
{
    public async Task<IEnumerable<PromotionStatus>> GetAllAsync() => await repository.GetAllAsync();
    public async Task<PromotionStatus> GetByIdAsync(int id) => await repository.GetByIdAsync(id);
    public async Task AddAsync(PromotionStatus entity) => repository.AddAsync(entity);
    public async Task UpdateAsync(PromotionStatus entity) => repository.UpdateAsync(entity);
    public async Task DeleteAsync(PromotionStatus entity) => repository.DeleteAsync(entity);
}