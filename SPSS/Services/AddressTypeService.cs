
using System.Collections.Generic;
using SPSS.Entities;
using SPSS.Repositories.GenericRepository;

public class AddressTypeService
{
    private readonly IGenericRepository<AddressType> _repository;

    public AddressTypeService(IGenericRepository<AddressType> repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<AddressType>> GetAllAsync() => await _repository.GetAllAsync();
    public async Task<AddressType> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);
    public async Task AddAsync(AddressType entity) => _repository.AddAsync(entity);
    public async Task UpdateAsync(AddressType entity) => _repository.UpdateAsync(entity);
    public async Task DeleteAsync(AddressType entity) => _repository.DeleteAsync(entity);
}