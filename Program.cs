using ApiCrud.Data;
using ApiCrud.Estudantes;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Injeção de dependência
builder.Services.AddScoped<AppDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Isso é possível porque, dentro do método `AdicionarRotasEstudantes` da classe
// `EstudantesRoutes`, declaramos o parâmetro `app` com a keyword `this`.
// Isso é chamado de extensão, quer dizer que aquele método está sendo adicionado à classe que ele extendeu e,
// logo, poderá ser chamado por esta.
// 
// ```
// public static class EstudantesRoutes {
//  public static void AdicionarRotasEstudantes(**this WebApplication app**) {}
// }
// ```
// 
// Agora o app, que é uma instância da classe WebApplication, pode chamar o método que foi adicionado como
// uma extensão à ela.
// 
// Assim, vamos disso:
// EstudantesRoutes.AdicionarRotasEstudantes(app);
// pra isso:
app.AdicionarRotasEstudantes();

app.Run();
