
using System.Collections.Generic;
using SPSS.Entities;
using SPSS.Repositories.GenericRepository;

public class OrderItemService (IGenericRepository<OrderItem> repository)
{
    public async Task<IEnumerable<OrderItem>> GetAllAsync() => await repository.GetAllAsync();
    public async Task<OrderItem> GetByIdAsync(int id) => await repository.GetByIdAsync(id);
    public async Task AddAsync(OrderItem entity) => repository.AddAsync(entity);
    public async Task UpdateAsync(OrderItem entity) => repository.UpdateAsync(entity);
    public async Task DeleteAsync(OrderItem entity) => repository.DeleteAsync(entity);
}