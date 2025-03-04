
using System.Collections.Generic;
using SPSS.Entities;
using SPSS.Repositories.GenericRepository;

public class AnswerDetailService (IGenericRepository<AnswerDetail> repository)
{
    public async Task<IEnumerable<AnswerDetail>> GetAllAsync() => await repository.GetAllAsync();
    public async Task<AnswerDetail> GetByIdAsync(int id) => await repository.GetByIdAsync(id);
    public async Task AddAsync(AnswerDetail entity) => repository.AddAsync(entity);
    public async Task UpdateAsync(AnswerDetail entity) => repository.UpdateAsync(entity);
    public async Task DeleteAsync(AnswerDetail entity) => repository.DeleteAsync(entity);
}