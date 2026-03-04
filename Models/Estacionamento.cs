using System;
using System.Collections.Generic;
using System.Globalization;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<Veiculo> veiculos = new List<Veiculo>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(placa))
            {
                Console.WriteLine("Placa Inválida"); 
                return;
            }
            veiculos.Add(new Veiculo(placa) { DataEntrada= DateTime.Now});

            Console.WriteLine("Veículo adicionado com sucesso.");

        }

        public void RemoverVeiculo()
        {
            Console.Write("Digite a placa do veículo para remover:");
            string placa = Console.ReadLine().ToUpper();
            var veiculo = veiculos. FirstOrDefault(v => v.Placa.ToUpper() == placa);  
           
                if (veiculo == null)
           
            {
               Console.WriteLine("Veiculo não encontrado.");
                    return;
            }

               TimeSpan tempoPermanencia= DateTime.Now - veiculo.DataEntrada;

               double horasTotais = tempoPermanencia.TotalHours;
               decimal valorTotal = precoInicial + ((decimal)horasTotais * precoPorHora);
               valorTotal= Math.Round (valorTotal,2);

               Console.WriteLine("\n===== RESUMO DA COBRANÇA =====");
               Console.WriteLine($"Placa:{veiculo.Placa}");
               Console.WriteLine($"Tempo estacionado:{tempoPermanencia.Days}d {tempoPermanencia.Hours}h {tempoPermanencia.Minutes}min");
               var culturaBR = new CultureInfo("pt-BR");
               Console.WriteLine($"Valor total a pagar:{valorTotal.ToString("C2", culturaBR)}");

               veiculos.Remove(veiculo);
               Console.WriteLine($"Veículo removido com sucesso.");
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");

                int contador = 1;

                foreach (var veiculo in veiculos)
                {
                  Console.WriteLine($"{contador} -Placa: {veiculo.Placa} | Entrada:{veiculo.DataEntrada}");
                  contador++;  
                }
                
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
