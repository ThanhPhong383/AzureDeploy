
using System.Collections.Generic;
using SPSS.Entities;
using SPSS.Repositories.GenericRepository;

public class AppUserService (IGenericRepository<AppUser> repository)
{
    public async Task<IEnumerable<AppUser>> GetAllAsync() => await repository.GetAllAsync();
    public async Task<AppUser> GetByIdAsync(int id) => await repository.GetByIdAsync(id);
    public async Task AddAsync(AppUser entity) =>   await repository.AddAsync(entity);
    public async Task UpdateAsync(AppUser entity) => await repository.UpdateAsync(entity);
    public async Task DeleteAsync(AppUser entity) => await  repository.DeleteAsync(entity);
}