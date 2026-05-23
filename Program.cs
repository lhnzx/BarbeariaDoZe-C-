using System;
using System.Collections.Generic;
using System.Linq;

// Classe principal do projeto
public class Program
{
    public static void Main()
    {
        bool sistemaRodando = true;

        // Lista de serviços disponíveis na barbearia
        List<Servico> servicos = new List<Servico>()
        {
            new Corte("Corte Masculino", 40.00m, 45, "Degradê"),
            new Barba("Barba Completa", 30.00m, 30, "Barba desenhada"),
            new Combo("Corte + Barba", 60.00m, 70, "Desconto no pacote")
        };

        // Lista de barbeiros disponíveis para atendimento
        List<Barbeiro> barbeiros = new List<Barbeiro>()
        {
            new Barbeiro("José Ferreira", "16992622983", "ze@barbearia.com", 4.9m),
            new Barbeiro("Carlos Lima", "16999998888", "carlos@barbearia.com", 4.8m)
        };

        while (sistemaRodando)
        {
            Console.Clear();
            Console.WriteLine("===== BARBEARIA DO ZÉ =====");
            Console.WriteLine("1 - Ver serviços");
            Console.WriteLine("2 - Ver barbeiros");
            Console.WriteLine("3 - Realizar agendamento");
            Console.WriteLine("0 - Sair");
            Console.Write("\nEscolha uma opção: ");

            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    ExibirServicos(servicos);
                    break;

                case "2":
                    ExibirBarbeiros(barbeiros);
                    break;

                case "3":
                    RealizarAgendamento(servicos, barbeiros);
                    break;

                case "0":
                    sistemaRodando = false;
                    break;

                default:
                    Console.WriteLine("\nOpção inválida.");
                    Console.ReadKey();
                    break;
            }
        }
    }

    // Método responsável por exibir o tipo correto de serviço
    public static void ExibirDetalhesServico(Servico servico)
    {
        if (servico is Corte corte)
        {
            corte.ExibirDetalhesCorte();
        }
        else if (servico is Barba barba)
        {
            barba.ExibirDetalhesBarba();
        }
        else if (servico is Combo combo)
        {
            combo.ExibirDetalhesCombo();
        }
        else
        {
            servico.ExibirDetalhes();
        }
    }

    // Método responsável por exibir todos os serviços cadastrados na lista
    static void ExibirServicos(List<Servico> servicos)
    {
        Console.Clear();
        Console.WriteLine("===== SERVIÇOS DISPONÍVEIS =====\n");

        for (int i = 0; i < servicos.Count; i++)
        {
            Console.WriteLine($"Opção {i + 1}:");
            ExibirDetalhesServico(servicos[i]);
            Console.WriteLine();
        }

        Console.WriteLine("Pressione qualquer tecla para voltar ao menu.");
        Console.ReadKey();
    }

    // Método responsável por exibir os barbeiros disponíveis
    static void ExibirBarbeiros(List<Barbeiro> barbeiros)
    {
        Console.Clear();
        Console.WriteLine("===== BARBEIROS DISPONÍVEIS =====\n");

        foreach (Barbeiro barbeiro in barbeiros)
        {
            barbeiro.ExibirDadosBarbeiro();
            Console.WriteLine();
        }

        Console.WriteLine("Pressione qualquer tecla para voltar ao menu.");
        Console.ReadKey();
    }

    // Método responsável por cadastrar os dados básicos do cliente
    static Cliente CadastrarCliente()
    {
        Console.Clear();
        Console.WriteLine("===== CADASTRO DO CLIENTE =====\n");

        string nome;
        do
        {
            Console.Write("Nome: ");
            nome = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(nome) || !ApenasLetras(nome))
            {
                Console.WriteLine("Digite um nome válido, contendo apenas letras.");
            }

        } while (string.IsNullOrWhiteSpace(nome) || !ApenasLetras(nome));

        string telefone;
        do
        {
            Console.Write("Telefone: ");
            telefone = Console.ReadLine();
            telefone = telefone.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");

            if (telefone.Length != 11 || !telefone.All(char.IsDigit))
            {
                Console.WriteLine("O telefone deve conter 11 números, incluindo o DDD.");
            }

        } while (telefone.Length != 11 || !telefone.All(char.IsDigit));

        string email;
        do
        {
            Console.Write("E-mail: ");
            email = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(email) || !email.Contains("@") || !email.Contains("."))
            {
                Console.WriteLine("Digite um e-mail válido.");
            }

        } while (string.IsNullOrWhiteSpace(email) || !email.Contains("@") || !email.Contains("."));

        return new Cliente(nome, telefone, email);
    }

    // Método responsável por permitir a escolha de um serviço
    static Servico EscolherServico(List<Servico> servicos)
    {
        int indice;
        bool escolhaValida = false;

        do
        {
            Console.Clear();
            Console.WriteLine("===== ESCOLHA O SERVIÇO =====\n");

            for (int i = 0; i < servicos.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {servicos[i].Nome} - R$ {servicos[i].Preco:F2}");
            }

            Console.Write("\nOpção: ");
            escolhaValida = int.TryParse(Console.ReadLine(), out indice)
                             && indice >= 1
                             && indice <= servicos.Count;

            if (!escolhaValida)
            {
                Console.WriteLine("Serviço inválido.");
                Console.ReadKey();
            }

        } while (!escolhaValida);

        return servicos[indice - 1];
    }

    // Método responsável por permitir a escolha de um barbeiro
    static Barbeiro EscolherBarbeiro(List<Barbeiro> barbeiros)
    {
        int indice;
        bool escolhaValida = false;

        do
        {
            Console.Clear();
            Console.WriteLine("===== ESCOLHA O BARBEIRO =====\n");

            for (int i = 0; i < barbeiros.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {barbeiros[i].Nome} | Avaliação: {barbeiros[i].Avaliacao:F1}/5");
            }

            Console.Write("\nOpção: ");
            escolhaValida = int.TryParse(Console.ReadLine(), out indice)
                             && indice >= 1
                             && indice <= barbeiros.Count;

            if (!escolhaValida)
            {
                Console.WriteLine("Barbeiro inválido.");
                Console.ReadKey();
            }

        } while (!escolhaValida);

        return barbeiros[indice - 1];
    }

    // Método responsável por reunir cliente, serviço, barbeiro e horário
    static void RealizarAgendamento(List<Servico> servicos, List<Barbeiro> barbeiros)
    {
        Cliente cliente = CadastrarCliente();
        Servico servicoEscolhido = EscolherServico(servicos);
        Barbeiro barbeiroEscolhido = EscolherBarbeiro(barbeiros);

        DateTime dataHora;
        bool dataValida;

        do
        {
            Console.Clear();
            Console.Write("Digite a data e horário do agendamento (dd/mm/aaaa hh:mm): ");
            dataValida = DateTime.TryParse(Console.ReadLine(), out dataHora);

            if (!dataValida)
            {
                Console.WriteLine("Data ou horário inválido.");
                Console.ReadKey();
            }

        } while (!dataValida);

        Agendamento agendamento = new Agendamento(cliente, barbeiroEscolhido, servicoEscolhido, dataHora);

        // Associação entre cliente e agendamento
        cliente.AgendamentoRealizado = agendamento;

        Console.Clear();
        agendamento.ExibirResumo();

        Console.WriteLine("\nAgendamento realizado com sucesso!");
        Console.WriteLine("Pressione qualquer tecla para voltar ao menu.");
        Console.ReadKey();
    }

    // Método auxiliar usado para validar nomes
    static bool ApenasLetras(string texto)
    {
        return texto.All(c => char.IsLetter(c) || char.IsWhiteSpace(c));
    }
}


