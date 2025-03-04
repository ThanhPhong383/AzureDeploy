
using System.Collections.Generic;
using SPSS.Entities;
using SPSS.Repositories.GenericRepository;

public class OrderService (IGenericRepository<Order> repository)
{
    public async Task<IEnumerable<Order>> GetAllAsync() => await repository.GetAllAsync();
    public async Task<Order> GetByIdAsync(int id) => await repository.GetByIdAsync(id);
    public async Task AddAsync(Order entity) => repository.AddAsync(entity);
    public async Task UpdateAsync(Order entity) => repository.UpdateAsync(entity);
    public async Task DeleteAsync(Order entity) => repository.DeleteAsync(entity);
}