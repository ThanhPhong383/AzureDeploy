
using System.Collections.Generic;
using SPSS.Entities;
using SPSS.Repositories.GenericRepository;

public class PaymentService
{
    private readonly IGenericRepository<Payment> _repository;

    public PaymentService(IGenericRepository<Payment> repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Payment>> GetAllAsync() => await _repository.GetAllAsync();
    public async Task<Payment> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);
    public async Task AddAsync(Payment entity) => _repository.AddAsync(entity);
    public async Task UpdateAsync(Payment entity) => _repository.UpdateAsync(entity);
    public async Task DeleteAsync(Payment entity) => _repository.DeleteAsync(entity);
}