
using System.Collections.Generic;
using SPSS.Entities;
using SPSS.Repositories.GenericRepository;

public class CartService
{
    private readonly IGenericRepository<Cart> _repository;

    public CartService(IGenericRepository<Cart> repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Cart>> GetAllAsync() => await _repository.GetAllAsync();
    public async Task<Cart> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);
    public async Task AddAsync(Cart entity) => _repository.AddAsync(entity);
    public async Task UpdateAsync(Cart entity) => _repository.UpdateAsync(entity);
    public async Task DeleteAsync(Cart entity) => _repository.DeleteAsync(entity);
}