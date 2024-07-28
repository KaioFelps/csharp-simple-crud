namespace ApiCrud.Estudantes;

public record EstudanteDto(Guid id, string nome);

public static class EstudantePresenter
{
    public static EstudanteDto ToHttp(Estudante estudante)
    {
        return new EstudanteDto(estudante.Id, estudante.Nome);
    }
}