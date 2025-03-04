
using System.Collections.Generic;
using SPSS.Entities;
using SPSS.Repositories.GenericRepository;

public class AnswerDetailService
{
    private readonly IGenericRepository<AnswerDetail> _repository;

    public AnswerDetailService(IGenericRepository<AnswerDetail> repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<AnswerDetail>> GetAllAsync() => await _repository.GetAllAsync();
    public async Task<AnswerDetail> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);
    public async Task AddAsync(AnswerDetail entity) => _repository.AddAsync(entity);
    public async Task UpdateAsync(AnswerDetail entity) => _repository.UpdateAsync(entity);
    public async Task DeleteAsync(AnswerDetail entity) => _repository.DeleteAsync(entity);
}