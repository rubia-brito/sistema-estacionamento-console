using System.Linq;
using DesafioFundamentos.Models;
using System.Globalization;

// Coloca o encoding para UTF8 para exibir acentuação
Console.OutputEncoding = System.Text.Encoding.UTF8;

CultureInfo culturaBR = new CultureInfo("pt-BR");
Console.WriteLine("Seja bem vindo ao sistema de estacionamento!");

Console.WriteLine("Digite o preço inicial:");
decimal precoInicial = decimal.Parse(Console.ReadLine(), culturaBR);

Console.WriteLine("Agora digite o preço por hora:");
decimal precoPorHora = decimal.Parse(Console.ReadLine(), culturaBR);

Console.WriteLine($"Preço inicial: {precoInicial.ToString("C2", culturaBR)}");
Console.WriteLine($"Preço por hora: {precoPorHora.ToString("C2", culturaBR)}");

// Instancia a classe Estacionamento, já com os valores obtidos anteriormente
Estacionamento es = new Estacionamento(precoInicial, precoPorHora);
Console.WriteLine("Pressione qualquer tecla para ir ao menu...");
Console.ReadKey();

string opcao = string.Empty;
bool exibirMenu = true;

// Realiza o loop do menu
while (exibirMenu)
{
    
    Console.Clear();
    Console.WriteLine("Digite a sua opção:");
    Console.WriteLine("1 - Cadastrar veículo");
    Console.WriteLine("2 - Remover veículo");
    Console.WriteLine("3 - Listar veículos");
    Console.WriteLine("4 - Encerrar");

    switch (Console.ReadLine())
    {
        case "1":
            es.AdicionarVeiculo();
            break;

        case "2":
            es.RemoverVeiculo();
            break;

        case "3":
            es.ListarVeiculos();
            break;

        case "4":
            exibirMenu = false;
            break;

       
    }
    if (exibirMenu)
    
    {
      Console.WriteLine("Pressione uma tecla para continuar");
      Console.ReadLine();  
    }
    
}

Console.WriteLine("O programa se encerrou"); 