using System;

// Classe base que representa um serviço oferecido pela barbearia
public class Servico
{
    // Propriedades comuns entre os serviços
    public string Nome { get; set; }
    public decimal Preco { get; set; }
    public int TempoEstimado { get; set; }

    // Construtor responsável por inicializar os dados principais
    public Servico(string nome, decimal preco, int tempoEstimado)
    {
        Nome = nome;
        Preco = preco;
        TempoEstimado = tempoEstimado;
    }

    // Método responsável por exibir as informações comuns do serviço
    public void ExibirDetalhes()
    {
        Console.WriteLine($"Serviço: {Nome}");
        Console.WriteLine($"Preço: R$ {Preco:F2}");
        Console.WriteLine($"Tempo estimado: {TempoEstimado} minutos");
    }
}
