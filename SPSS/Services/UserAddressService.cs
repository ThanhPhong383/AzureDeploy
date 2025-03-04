
using System.Collections.Generic;
using SPSS.Entities;
using SPSS.Repositories.GenericRepository;

public class UserAddressService
{
    private readonly IGenericRepository<UserAddress> _repository;

    public UserAddressService(IGenericRepository<UserAddress> repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<UserAddress>> GetAllAsync() => await _repository.GetAllAsync();
    public async Task<UserAddress> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);
    public async Task AddAsync(UserAddress entity) => _repository.AddAsync(entity);
    public async Task UpdateAsync(UserAddress entity) => _repository.UpdateAsync(entity);
    public async Task DeleteAsync(UserAddress entity) => _repository.DeleteAsync(entity);
}