
using System.Collections.Generic;
using SPSS.Entities;
using SPSS.Repositories.GenericRepository;

public class AnswerSheetService (IGenericRepository<AnswerSheet> repository)
{
    public async Task<IEnumerable<AnswerSheet>> GetAllAsync() => await repository.GetAllAsync();
    public async Task<AnswerSheet> GetByIdAsync(int id) => await repository.GetByIdAsync(id);
    public async Task AddAsync(AnswerSheet entity) => repository.AddAsync(entity);
    public async Task UpdateAsync(AnswerSheet entity) => repository.UpdateAsync(entity);
    public async Task DeleteAsync(AnswerSheet entity) => repository.DeleteAsync(entity);
}