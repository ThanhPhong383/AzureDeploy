
using System.Collections.Generic;
using SPSS.Entities;
using SPSS.Repositories.GenericRepository;

public class CartService (IGenericRepository<Cart> repository)
{
    public async Task<IEnumerable<Cart>> GetAllAsync() => await repository.GetAllAsync();
    public async Task<Cart> GetByIdAsync(int id) => await repository.GetByIdAsync(id);
    public async Task AddAsync(Cart entity) => repository.AddAsync(entity);
    public async Task UpdateAsync(Cart entity) => repository.UpdateAsync(entity);
    public async Task DeleteAsync(Cart entity) => repository.DeleteAsync(entity);
}