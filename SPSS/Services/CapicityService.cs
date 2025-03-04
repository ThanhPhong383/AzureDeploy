
using System.Collections.Generic;
using SPSS.Entities;
using SPSS.Repositories.GenericRepository;

public class CapicityService
{
    private readonly IGenericRepository<Capicity> _repository;

    public CapicityService(IGenericRepository<Capicity> repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Capicity>> GetAllAsync() => await _repository.GetAllAsync();
    public async Task<Capicity> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);
    public async Task AddAsync(Capicity entity) => _repository.AddAsync(entity);
    public async Task UpdateAsync(Capicity entity) => _repository.UpdateAsync(entity);
    public async Task DeleteAsync(Capicity entity) => _repository.DeleteAsync(entity);
}