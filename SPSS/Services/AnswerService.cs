
using System.Collections.Generic;
using SPSS.Entities;
using SPSS.Repositories.GenericRepository;

public class AnswerService
{
    private readonly IGenericRepository<Answer> _repository;

    public AnswerService(IGenericRepository<Answer> repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Answer>> GetAllAsync() => await _repository.GetAllAsync();
    public async Task<Answer> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);
    public async Task AddAsync(Answer entity) => _repository.AddAsync(entity);
    public async Task UpdateAsync(Answer entity) => _repository.UpdateAsync(entity);
    public async Task DeleteAsync(Answer entity) => _repository.DeleteAsync(entity);
}