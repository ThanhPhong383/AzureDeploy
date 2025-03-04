
using System.Collections.Generic;
using SPSS.Entities;
using SPSS.Repositories.GenericRepository;

public class PromotionService
{
    private readonly IGenericRepository<Promotion> _repository;

    public PromotionService(IGenericRepository<Promotion> repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Promotion>> GetAllAsync() => await _repository.GetAllAsync();
    public async Task<Promotion> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);
    public async Task AddAsync(Promotion entity) => _repository.AddAsync(entity);
    public async Task UpdateAsync(Promotion entity) => _repository.UpdateAsync(entity);
    public async Task DeleteAsync(Promotion entity) => _repository.DeleteAsync(entity);
}