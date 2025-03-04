
using System.Collections.Generic;
using SPSS.Entities;
using SPSS.Repositories.GenericRepository;

public class RoutinesService
{
    private readonly IGenericRepository<Routines> _repository;

    public RoutinesService(IGenericRepository<Routines> repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Routines>> GetAllAsync() => await _repository.GetAllAsync();
    public async Task<Routines> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);
    public async Task AddAsync(Routines entity) => _repository.AddAsync(entity);
    public async Task UpdateAsync(Routines entity) => _repository.UpdateAsync(entity);
    public async Task DeleteAsync(Routines entity) => _repository.DeleteAsync(entity);
}