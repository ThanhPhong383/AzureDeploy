
using System.Collections.Generic;
using SPSS.Entities;
using SPSS.Repositories.GenericRepository;

public class AppUserService
{
    private readonly IGenericRepository<AppUser> _repository;

    public AppUserService(IGenericRepository<AppUser> repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<AppUser>> GetAllAsync() => await _repository.GetAllAsync();
    public async Task<AppUser> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);
    public async Task AddAsync(AppUser entity) => _repository.AddAsync(entity);
    public async Task UpdateAsync(AppUser entity) => _repository.UpdateAsync(entity);
    public async Task DeleteAsync(AppUser entity) => _repository.DeleteAsync(entity);
}