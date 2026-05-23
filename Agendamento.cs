using System;

// Classe responsável por reunir cliente, barbeiro, serviço e data escolhida
public class Agendamento
{
    public Cliente Cliente { get; set; }
    public Barbeiro Barbeiro { get; set; }
    public Servico ServicoEscolhido { get; set; }
    public DateTime DataHora { get; set; }
    public string Status { get; set; }

    // Construtor responsável por receber as informações do agendamento
    public Agendamento(Cliente cliente, Barbeiro barbeiro, Servico servicoEscolhido, DateTime dataHora)
    {
        Cliente = cliente;
        Barbeiro = barbeiro;
        ServicoEscolhido = servicoEscolhido;
        DataHora = dataHora;
        Status = "Confirmado";
    }

    // Método responsável por exibir o resumo final do agendamento
    public void ExibirResumo()
    {
        Console.WriteLine("===== RESUMO DO AGENDAMENTO =====\n");
        Console.WriteLine($"Cliente: {Cliente.Nome}");
        Console.WriteLine($"Barbeiro: {Barbeiro.Nome}");
        Console.WriteLine($"Data e horário: {DataHora:dd/MM/yyyy HH:mm}");
        Console.WriteLine($"Status: {Status}\n");

        Program.ExibirDetalhesServico(ServicoEscolhido);
    }
}
