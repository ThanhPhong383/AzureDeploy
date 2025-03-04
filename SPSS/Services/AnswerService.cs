
using System.Collections.Generic;
using SPSS.Entities;
using SPSS.Repositories.GenericRepository;

public class AnswerService (IGenericRepository<Answer> repository)
{
    public async Task<IEnumerable<Answer>> GetAllAsync() => await repository.GetAllAsync();
    public async Task<Answer> GetByIdAsync(int id) => await repository.GetByIdAsync(id);
    public async Task AddAsync(Answer entity) => await repository.AddAsync(entity);
    public async Task UpdateAsync(Answer entity) => await repository.UpdateAsync(entity);
    public async Task DeleteAsync(Answer entity) => await repository.DeleteAsync(entity);
}