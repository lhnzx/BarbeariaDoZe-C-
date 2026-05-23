using System;

// Classe Combo herda de Servico e representa um pacote de atendimento
public class Combo : Servico
{
    public string Beneficio { get; set; }

    // O base envia os dados comuns para a classe Servico
    public Combo(string nome, decimal preco, int tempoEstimado, string beneficio)
        : base(nome, preco, tempoEstimado)
    {
        Beneficio = beneficio;
    }

    // Método usado para exibir os dados comuns e o benefício do combo
    public void ExibirDetalhesCombo()
    {
        ExibirDetalhes();
        Console.WriteLine($"Benefício: {Beneficio}");
    }
}
