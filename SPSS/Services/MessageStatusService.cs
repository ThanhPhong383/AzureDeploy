
using System.Collections.Generic;
using SPSS.Entities;
using SPSS.Repositories.GenericRepository;

public class MessageStatusService (IGenericRepository<MessageStatus> repository)
{
    public async Task<IEnumerable<MessageStatus>> GetAllAsync() => await repository.GetAllAsync();
    public async Task<MessageStatus> GetByIdAsync(int id) => await repository.GetByIdAsync(id);
    public async Task AddAsync(MessageStatus entity) => repository.AddAsync(entity);
    public async Task UpdateAsync(MessageStatus entity) => repository.UpdateAsync(entity);
    public async Task DeleteAsync(MessageStatus entity) => repository.DeleteAsync(entity);
}