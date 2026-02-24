using System.Net.Http.Json;
using MyApp.Models;

namespace MyApp.Services;

public class FuncionarioService : IFuncionarioService
{
    private readonly HttpClient _http;

    public FuncionarioService(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<FuncionarioDto>> GetAllAsync()
    {
        // Em entrevista, você pode dizer: "Aqui eu usaria Polly para retry"
        return await _http.GetFromJsonAsync<List<FuncionarioDto>>("/api/funcionarios")
            ?? new List<FuncionarioDto>();
    }

    public async Task<FuncionarioDto?> GetByIdAsync(int id)
    {
        var response = await _http.GetAsync($"/api/funcionarios/{id}");
        
        // Tratamento simples: se 404, retorna null (não lança exceção)
        if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            return null;

        response.EnsureSuccessStatusCode(); // Lança exceção se não for 2xx
        return await response.Content.ReadFromJsonAsync<FuncionarioDto>();
    }

    public async Task<int> CreateAsync(FuncionarioDto dto)
    {
        var response = await _http.PostAsJsonAsync("/api/funcionarios", dto);
        response.EnsureSuccessStatusCode();

        // Se a API retornar o objeto criado, extraímos o ID
        var created = await response.Content.ReadFromJsonAsync<FuncionarioDto>();
        return created?.Id ?? 0;
    }

    public async Task UpdateAsync(int id, FuncionarioDto dto)
    {
        var response = await _http.PutAsJsonAsync($"/api/funcionarios/{id}", dto);
        response.EnsureSuccessStatusCode();
    }

    public async Task DeleteAsync(int id)
    {
        var response = await _http.DeleteAsync($"/api/funcionarios/{id}");
        response.EnsureSuccessStatusCode();
    }
}
