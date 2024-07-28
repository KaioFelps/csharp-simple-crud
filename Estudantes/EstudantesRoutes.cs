using ApiCrud.Data;
using Microsoft.EntityFrameworkCore;

namespace ApiCrud.Estudantes;

public static class EstudantesRoutes
{
 public static void AdicionarRotasEstudantes(this WebApplication app)
 {
  var rotasEstudantes = app.MapGroup("estudantes");

  rotasEstudantes.MapPost("criar", async (CriarEstudanteRequest request, AppDbContext ctx, CancellationToken cancelToken) =>
  {
   var jaExiste = await ctx.Estudantes.AnyAsync(estudante => estudante.Nome == request.Nome, cancelToken);

   if (jaExiste)
    return Results.Conflict("Já existe");
   
   var novoEstudante = new Estudante(request.Nome);
   await ctx.Estudantes.AddAsync(novoEstudante, cancelToken);
   await ctx.SaveChangesAsync(cancelToken);

   var estudanteMapeado = EstudantePresenter.ToHttp(novoEstudante);
   
   return Results.Ok(estudanteMapeado);
  });

  rotasEstudantes.MapGet("", async (AppDbContext ctx, CancellationToken cancelToken) =>
  {
   var estudantes = await ctx.Estudantes
    .Where(estudante => estudante.Ativo)
    .ToListAsync(cancelToken);

   var estudantesMapeados = estudantes.Select(EstudantePresenter.ToHttp).ToList();
   return Results.Ok(estudantesMapeados);
  });

  rotasEstudantes.MapPut("{estudanteId}/update",
   async (Guid estudanteId, AtualizarEstudanteRequest request, AppDbContext ctx, CancellationToken cancelToken) =>
   {
    var estudante = await ctx.Estudantes.FindAsync(new object[] { estudanteId }, cancelToken);

    if (estudante == null)
    {
     return Results.BadRequest("Estudante não encontrado.");
    }

    estudante.SetNome(request.nome);
    await ctx.SaveChangesAsync(cancelToken);

    var estudanteMapeado = EstudantePresenter.ToHttp(estudante);
    
    return Results.Ok(estudanteMapeado);
   });

  rotasEstudantes.MapPatch("{id}/delete", async (Guid id, AppDbContext ctx, CancellationToken cancelToken) =>
  {
   var estudante = await ctx.Estudantes.FindAsync(new object[] { id }, cancelToken);

   if (estudante == null) return Results.BadRequest("Estudante não encontrado.");
   
   estudante.Deactivate();
   await ctx.SaveChangesAsync(cancelToken);

   return Results.NoContent();
  });

  rotasEstudantes.MapDelete("{id}/destroy", async (Guid id, AppDbContext ctx, CancellationToken cancelToken) =>
  {
   var estudante = await ctx.Estudantes.FindAsync(new object[] { id }, cancelToken);

   if (estudante == null) return Results.BadRequest("Estudante não encontrado.");

   ctx.Estudantes.Remove(estudante);
   await ctx.SaveChangesAsync(cancelToken);
   return Results.NoContent();
  });
 }   
}