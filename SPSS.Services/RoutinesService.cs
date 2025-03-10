
using System.Collections.Generic;
using SPSS.Entities;
using SPSS.Repositories.GenericRepository;

public class RoutinesService (IGenericRepository<Routines> repository)
{
    public async Task<IEnumerable<Routines>> GetAllAsync() => await repository.GetAllAsync();
    public async Task<Routines> GetByIdAsync(int id) => await repository.GetByIdAsync(id);
    public async Task AddAsync(Routines entity) => await repository.AddAsync(entity);
    public async Task UpdateAsync(Routines entity) => await repository.UpdateAsync(entity);
    public async Task DeleteAsync(Routines entity) => await repository.DeleteAsync(entity);
}