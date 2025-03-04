
using System.Collections.Generic;
using SPSS.Entities;
using SPSS.Repositories.GenericRepository;

public class CapicityService (IGenericRepository<Capicity> repository)
{
    public async Task<IEnumerable<Capicity>> GetAllAsync() => await repository.GetAllAsync();
    public async Task<Capicity> GetByIdAsync(int id) => await repository.GetByIdAsync(id);
    public async Task AddAsync(Capicity entity) => repository.AddAsync(entity);
    public async Task UpdateAsync(Capicity entity) => repository.UpdateAsync(entity);
    public async Task DeleteAsync(Capicity entity) => repository.DeleteAsync(entity);
}