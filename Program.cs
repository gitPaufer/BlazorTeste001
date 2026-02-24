// Registrar o HttpClient com BaseAddress
builder.Services.AddHttpClient<IFuncionarioService, FuncionarioService>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration["ApiBaseUrl"] ?? "https://localhost:5001");
});

// Se você quiser usar a API no mesmo host (sem config), faça:
// builder.Services.AddScoped<IFuncionarioService, FuncionarioService>();
// e injete HttpClient (que já tem BaseAddress configurado no host)
