
using System.Collections.Generic;
using SPSS.Entities;
using SPSS.Repositories.GenericRepository;

public class OrderItemService
{
    private readonly IGenericRepository<OrderItem> _repository;

    public OrderItemService(IGenericRepository<OrderItem> repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<OrderItem>> GetAllAsync() => await _repository.GetAllAsync();
    public async Task<OrderItem> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);
    public async Task AddAsync(OrderItem entity) => _repository.AddAsync(entity);
    public async Task UpdateAsync(OrderItem entity) => _repository.UpdateAsync(entity);
    public async Task DeleteAsync(OrderItem entity) => _repository.DeleteAsync(entity);
}