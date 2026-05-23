using System;

// Classe base para pessoas que interagem com o sistema
public class Usuario
{
    public string Nome { get; set; }
    public string Telefone { get; set; }
    public string Email { get; set; }

    // Construtor usado para preencher os dados principais do usuário
    public Usuario(string nome, string telefone, string email)
    {
        Nome = nome;
        Telefone = telefone;
        Email = email;
    }

    // Método responsável por exibir os dados comuns
    public void ExibirDados()
    {
        Console.WriteLine($"Nome: {Nome}");
        Console.WriteLine($"Telefone: {Telefone}");
        Console.WriteLine($"E-mail: {Email}");
    }
}
