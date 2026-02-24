MyApp/
├── Components/
│   ├── Pages/
│   │   ├── Funcionarios.razor
│   │   └── FuncionarioForm.razor
│   └── Services/
│       └── IFuncionarioService.cs
│       └── FuncionarioService.cs
├── Models/
│   └── FuncionarioDto.cs
└── Program.cs

Service Layer:
“Eu separei a lógica de acesso a dados em um service. Isso facilita testes unitários (mock do service) e torna o código do componente mais limpo (Single Responsibility Principle).”

Tratamento de Erro:
“No service, eu uso EnsureSuccessStatusCode() para garantir que só retornemos dados válidos. Na UI, trato exceções e mostro mensagens amigáveis ao usuário.”

Injeção de Dependência:
“O HttpClient é injetado via DI, o que facilita a troca para outro service de infraestrutura (ex: usar IHttpClientFactory para evitar problemas de socket exhaustion).”

Render Mode:
“Como estamos usando Blazor Web App, eu escolhi InteractiveServer para este CRUD porque é mais rápido e simples. Se precisarmos de offline (PWA) ou para o registro de ponto, podemos trocar para InteractiveAuto ou InteractiveWebAssembly.”

Migração do .NET 4.8:
“Essa arquitetura com Service Layer e API separada é ideal para a migração do .NET 4.8. Podemos manter a mesma API enquanto migramos o frontend, e até usar o mesmo banco de dados (se a estrutura for compatível).”
