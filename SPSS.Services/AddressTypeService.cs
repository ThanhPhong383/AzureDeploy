
using System.Collections.Generic;
using SPSS.Entities;
using SPSS.Repositories.GenericRepository;

public class AddressTypeService (IGenericRepository<AddressType> repository)
{
    public async Task<IEnumerable<AddressType>> GetAllAsync() => await repository.GetAllAsync();
    public async Task<AddressType> GetByIdAsync(int id) => await repository.GetByIdAsync(id);
    public async Task AddAsync(AddressType entity) => await repository.AddAsync(entity);
    public async Task UpdateAsync(AddressType entity) => await repository.UpdateAsync(entity);
    public async Task DeleteAsync(AddressType entity) => await repository.DeleteAsync(entity);
}