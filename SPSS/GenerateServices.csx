using System;
using System.IO;
using System.Linq;


string entitiesPath = Path.Combine(Directory.GetCurrentDirectory(), "Entities");


string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "Services");


if (!Directory.Exists(outputPath))
    Directory.CreateDirectory(outputPath);


var entityFiles = Directory.GetFiles(entitiesPath, "*.cs");

foreach (var file in entityFiles)
{
    string entityName = Path.GetFileNameWithoutExtension(file);


    string serviceCode = $@"
using System.Collections.Generic;
using SPSS.Entities;
using SPSS.Repositories.GenericRepository;

public class {entityName}Service (IGenericRepository<{entityName}> repository)
{{
    public async Task<IEnumerable<{entityName}>> GetAllAsync() => await repository.GetAllAsync();
    public async Task<{entityName}> GetByIdAsync(int id) => await repository.GetByIdAsync(id);
    public async Task AddAsync({entityName} entity) => repository.AddAsync(entity);
    public async Task UpdateAsync({entityName} entity) => repository.UpdateAsync(entity);
    public async Task DeleteAsync({entityName} entity) => repository.DeleteAsync(entity);
}}";

    string outputFilePath = Path.Combine(outputPath, $"{entityName}Service.cs");
    File.WriteAllText(outputFilePath, serviceCode);
    Console.WriteLine($"Generated: {outputFilePath}");
}

Console.WriteLine("Services generated successfully!");