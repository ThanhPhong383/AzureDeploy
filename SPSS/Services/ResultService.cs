
using System.Collections.Generic;
using SPSS.Entities;
using SPSS.Repositories.GenericRepository;

public class ResultService
{
    private readonly IGenericRepository<Result> _repository;

    public ResultService(IGenericRepository<Result> repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Result>> GetAllAsync() => await _repository.GetAllAsync();
    public async Task<Result> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);
    public async Task AddAsync(Result entity) => _repository.AddAsync(entity);
    public async Task UpdateAsync(Result entity) => _repository.UpdateAsync(entity);
    public async Task DeleteAsync(Result entity) => _repository.DeleteAsync(entity);
}