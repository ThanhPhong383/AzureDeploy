
using System.Collections.Generic;
using SPSS.Entities;
using SPSS.Repositories.GenericRepository;

public class QuestionService
{
    private readonly IGenericRepository<Question> _repository;

    public QuestionService(IGenericRepository<Question> repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Question>> GetAllAsync() => await _repository.GetAllAsync();
    public async Task<Question> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);
    public async Task AddAsync(Question entity) => _repository.AddAsync(entity);
    public async Task UpdateAsync(Question entity) => _repository.UpdateAsync(entity);
    public async Task DeleteAsync(Question entity) => _repository.DeleteAsync(entity);
}