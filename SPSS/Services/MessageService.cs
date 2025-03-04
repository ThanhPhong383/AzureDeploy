
using System.Collections.Generic;
using SPSS.Entities;
using SPSS.Repositories.GenericRepository;

public class MessageService
{
    private readonly IGenericRepository<Message> _repository;

    public MessageService(IGenericRepository<Message> repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Message>> GetAllAsync() => await _repository.GetAllAsync();
    public async Task<Message> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);
    public async Task AddAsync(Message entity) => _repository.AddAsync(entity);
    public async Task UpdateAsync(Message entity) => _repository.UpdateAsync(entity);
    public async Task DeleteAsync(Message entity) => _repository.DeleteAsync(entity);
}