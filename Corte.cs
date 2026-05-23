using System;

// Classe Corte herda de Servico e adiciona uma informação própria
public class Corte : Servico
{
    public string TipoCorte { get; set; }

    // O base envia os dados comuns para a classe Servico
    public Corte(string nome, decimal preco, int tempoEstimado, string tipoCorte)
        : base(nome, preco, tempoEstimado)
    {
        TipoCorte = tipoCorte;
    }

    // Método usado para exibir os dados comuns e o tipo de corte
    public void ExibirDetalhesCorte()
    {
        ExibirDetalhes();
        Console.WriteLine($"Tipo de corte: {TipoCorte}");
    }
}
