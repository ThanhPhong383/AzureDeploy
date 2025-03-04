
using System.Collections.Generic;
using SPSS.Entities;
using SPSS.Repositories.GenericRepository;

public class OrderService
{
    private readonly IGenericRepository<Order> _repository;

    public OrderService(IGenericRepository<Order> repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Order>> GetAllAsync() => await _repository.GetAllAsync();
    public async Task<Order> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);
    public async Task AddAsync(Order entity) => _repository.AddAsync(entity);
    public async Task UpdateAsync(Order entity) => _repository.UpdateAsync(entity);
    public async Task DeleteAsync(Order entity) => _repository.DeleteAsync(entity);
}