using MyApp.Models;

namespace MyApp.Services;

public interface IFuncionarioService
{
    Task<List<FuncionarioDto>> GetAllAsync();
    Task<FuncionarioDto?> GetByIdAsync(int id);
    Task<int> CreateAsync(FuncionarioDto dto);
    Task UpdateAsync(int id, FuncionarioDto dto);
    Task DeleteAsync(int id);
}
