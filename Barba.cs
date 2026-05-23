using System;

// Classe Barba herda de Servico e adiciona uma informação própria
public class Barba : Servico
{
    public string TipoBarba { get; set; }

    // O base envia os dados comuns para a classe Servico
    public Barba(string nome, decimal preco, int tempoEstimado, string tipoBarba)
        : base(nome, preco, tempoEstimado)
    {
        TipoBarba = tipoBarba;
    }

    // Método usado para exibir os dados comuns e o tipo de barba
    public void ExibirDetalhesBarba()
    {
        ExibirDetalhes();
        Console.WriteLine($"Tipo de barba: {TipoBarba}");
    }
}
