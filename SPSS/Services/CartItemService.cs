
using System.Collections.Generic;
using SPSS.Entities;
using SPSS.Repositories.GenericRepository;

public class CartItemService (IGenericRepository<CartItem> repository)
{
    public async Task<IEnumerable<CartItem>> GetAllAsync() => await repository.GetAllAsync();
    public async Task<CartItem> GetByIdAsync(int id) => await repository.GetByIdAsync(id);
    public async Task AddAsync(CartItem entity) => repository.AddAsync(entity);
    public async Task UpdateAsync(CartItem entity) => repository.UpdateAsync(entity);
    public async Task DeleteAsync(CartItem entity) => repository.DeleteAsync(entity);
}