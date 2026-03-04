namespace DesafioFundamentos.Models
{
    public class Veiculo
    {
        public string Placa { get; set; }
        public DateTime DataEntrada { get; set;} 
    
    
         public Veiculo (string placa)
        {
        Placa= placa;
        DataEntrada = DateTime.Now;
        }
    }
}
