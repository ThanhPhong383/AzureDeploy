
using System.Collections.Generic;
using SPSS.Entities;
using SPSS.Repositories.GenericRepository;

public class QuestionService (IGenericRepository<Question> repository)
{
    public async Task<IEnumerable<Question>> GetAllAsync() => await repository.GetAllAsync();
    public async Task<Question> GetByIdAsync(int id) => await repository.GetByIdAsync(id);
    public async Task AddAsync(Question entity) => repository.AddAsync(entity);
    public async Task UpdateAsync(Question entity) => repository.UpdateAsync(entity);
    public async Task DeleteAsync(Question entity) => repository.DeleteAsync(entity);
}