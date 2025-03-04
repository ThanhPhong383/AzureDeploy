
using System.Collections.Generic;
using SPSS.Entities;
using SPSS.Repositories.GenericRepository;

public class CartItemService
{
    private readonly IGenericRepository<CartItem> _repository;

    public CartItemService(IGenericRepository<CartItem> repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<CartItem>> GetAllAsync() => await _repository.GetAllAsync();
    public async Task<CartItem> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);
    public async Task AddAsync(CartItem entity) => _repository.AddAsync(entity);
    public async Task UpdateAsync(CartItem entity) => _repository.UpdateAsync(entity);
    public async Task DeleteAsync(CartItem entity) => _repository.DeleteAsync(entity);
}