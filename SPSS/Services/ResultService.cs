
using System.Collections.Generic;
using SPSS.Entities;
using SPSS.Repositories.GenericRepository;

public class ResultService (IGenericRepository<Result> repository)
{
    public async Task<IEnumerable<Result>> GetAllAsync() => await repository.GetAllAsync();
    public async Task<Result> GetByIdAsync(int id) => await repository.GetByIdAsync(id);
    public async Task AddAsync(Result entity) => await repository.AddAsync(entity);
    public async Task UpdateAsync(Result entity) => await   repository.UpdateAsync(entity);
    public async Task DeleteAsync(Result entity) => await repository.DeleteAsync(entity);
}