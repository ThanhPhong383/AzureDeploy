
using System.Collections.Generic;
using SPSS.Entities;
using SPSS.Repositories.GenericRepository;

public class AddressService (IGenericRepository<Address> repository)
{
    public async Task<IEnumerable<Address>> GetAllAsync() => await repository.GetAllAsync();
    public async Task<Address> GetByIdAsync(int id) => await repository.GetByIdAsync(id);
    public async Task AddAsync(Address entity) => repository.AddAsync(entity);
    public async Task UpdateAsync(Address entity) => repository.UpdateAsync(entity);
    public async Task DeleteAsync(Address entity) => repository.DeleteAsync(entity);
}