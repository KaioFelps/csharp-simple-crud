using System.ComponentModel.DataAnnotations.Schema;

namespace ApiCrud.Estudantes;

[Table("estudantes")]
public class Estudante
{
    // init diz que, depois de setado, nada mais pode alterar este campo
    [Column("id")]
    public Guid Id { get; init; }
    
    // private set quer dizer que só pode ser alterado por dentro da classe
    [Column("nome")]
    public string Nome { get; private set; }
    
    [Column("ativo")]
    public bool Ativo { get; private set; }
    
    public Estudante(string nome)
    {
        Nome = nome;
        Id = Guid.NewGuid();
        Ativo = true;
    }

    public void SetNome(string nome)
    {
        Nome = nome;
    }

    public void Deactivate()
    {
        Ativo = false;
    }
}