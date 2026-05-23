using System;

// Cliente herda de Usuario e pode possuir um agendamento associado
public class Cliente : Usuario
{
    public Agendamento AgendamentoRealizado { get; set; }

    // O base envia nome, telefone e email para a classe Usuario
    public Cliente(string nome, string telefone, string email)
        : base(nome, telefone, email)
    {
    }
}
