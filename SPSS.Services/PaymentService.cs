
using System.Collections.Generic;
using SPSS.Entities;
using SPSS.Repositories.GenericRepository;

public class PaymentService (IGenericRepository<Payment> repository)
{
    public async Task<IEnumerable<Payment>> GetAllAsync() => await repository.GetAllAsync();
    public async Task<Payment> GetByIdAsync(int id) => await repository.GetByIdAsync(id);
    public async Task AddAsync(Payment entity) => await repository.AddAsync(entity);
    public async Task UpdateAsync(Payment entity) => await repository.UpdateAsync(entity);
    public async Task DeleteAsync(Payment entity) => await repository.DeleteAsync(entity);
}