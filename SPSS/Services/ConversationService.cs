
using System.Collections.Generic;
using SPSS.Entities;
using SPSS.Repositories.GenericRepository;

public class ConversationService
{
    private readonly IGenericRepository<Conversation> _repository;

    public ConversationService(IGenericRepository<Conversation> repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Conversation>> GetAllAsync() => await _repository.GetAllAsync();
    public async Task<Conversation> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);
    public async Task AddAsync(Conversation entity) => _repository.AddAsync(entity);
    public async Task UpdateAsync(Conversation entity) => _repository.UpdateAsync(entity);
    public async Task DeleteAsync(Conversation entity) => _repository.DeleteAsync(entity);
}