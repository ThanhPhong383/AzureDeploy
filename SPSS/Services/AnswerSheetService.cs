
using System.Collections.Generic;
using SPSS.Entities;
using SPSS.Repositories.GenericRepository;

public class AnswerSheetService
{
    private readonly IGenericRepository<AnswerSheet> _repository;

    public AnswerSheetService(IGenericRepository<AnswerSheet> repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<AnswerSheet>> GetAllAsync() => await _repository.GetAllAsync();
    public async Task<AnswerSheet> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);
    public async Task AddAsync(AnswerSheet entity) => _repository.AddAsync(entity);
    public async Task UpdateAsync(AnswerSheet entity) => _repository.UpdateAsync(entity);
    public async Task DeleteAsync(AnswerSheet entity) => _repository.DeleteAsync(entity);
}