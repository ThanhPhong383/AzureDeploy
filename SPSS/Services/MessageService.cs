
using System.Collections.Generic;
using SPSS.Entities;
using SPSS.Repositories.GenericRepository;

public class MessageService (IGenericRepository<Message> repository)
{
    public async Task<IEnumerable<Message>> GetAllAsync() => await repository.GetAllAsync();
    public async Task<Message> GetByIdAsync(int id) => await repository.GetByIdAsync(id);
    public async Task AddAsync(Message entity) => repository.AddAsync(entity);
    public async Task UpdateAsync(Message entity) => repository.UpdateAsync(entity);
    public async Task DeleteAsync(Message entity) => repository.DeleteAsync(entity);
}