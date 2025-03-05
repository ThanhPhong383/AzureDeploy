
using System.Collections.Generic;
using SPSS.Entities;
using SPSS.Repositories.GenericRepository;

public class UserAddressService (IGenericRepository<UserAddress> repository)
{
    public async Task<IEnumerable<UserAddress>> GetAllAsync() => await repository.GetAllAsync();
    public async Task<UserAddress> GetByIdAsync(int id) => await repository.GetByIdAsync(id);
    public async Task AddAsync(UserAddress entity) => await repository.AddAsync(entity);
    public async Task UpdateAsync(UserAddress entity) => await repository.UpdateAsync(entity);
    public async Task DeleteAsync(UserAddress entity) => await repository.DeleteAsync(entity);
}