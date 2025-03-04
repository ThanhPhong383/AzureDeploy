
using System.Collections.Generic;
using SPSS.Entities;
using SPSS.Repositories.GenericRepository;

public class ConversationService (IGenericRepository<Conversation> repository)
{
    public async Task<IEnumerable<Conversation>> GetAllAsync() => await repository.GetAllAsync();
    public async Task<Conversation> GetByIdAsync(int id) => await repository.GetByIdAsync(id);
    public async Task AddAsync(Conversation entity) => repository.AddAsync(entity);
    public async Task UpdateAsync(Conversation entity) => repository.UpdateAsync(entity);
    public async Task DeleteAsync(Conversation entity) => repository.DeleteAsync(entity);
}