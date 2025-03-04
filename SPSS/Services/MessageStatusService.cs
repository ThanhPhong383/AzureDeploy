
using System.Collections.Generic;
using SPSS.Entities;
using SPSS.Repositories.GenericRepository;

public class MessageStatusService
{
    private readonly IGenericRepository<MessageStatus> _repository;

    public MessageStatusService(IGenericRepository<MessageStatus> repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<MessageStatus>> GetAllAsync() => await _repository.GetAllAsync();
    public async Task<MessageStatus> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);
    public async Task AddAsync(MessageStatus entity) => _repository.AddAsync(entity);
    public async Task UpdateAsync(MessageStatus entity) => _repository.UpdateAsync(entity);
    public async Task DeleteAsync(MessageStatus entity) => _repository.DeleteAsync(entity);
}