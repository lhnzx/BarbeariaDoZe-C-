using System;

// Barbeiro herda de Usuario e adiciona a avaliação profissional
public class Barbeiro : Usuario
{
    public decimal Avaliacao { get; set; }

    // O construtor recebe os dados do usuário e a avaliação do barbeiro
    public Barbeiro(string nome, string telefone, string email, decimal avaliacao)
        : base(nome, telefone, email)
    {
        Avaliacao = avaliacao;
    }

    // Método responsável por exibir os dados do barbeiro
    public void ExibirDadosBarbeiro()
    {
        ExibirDados();
        Console.WriteLine($"Avaliação: {Avaliacao:F1}/5");
    }
}

