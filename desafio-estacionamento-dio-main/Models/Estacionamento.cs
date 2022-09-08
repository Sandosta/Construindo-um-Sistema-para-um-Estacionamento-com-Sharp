using System.Text.RegularExpressions;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            // TODO: Pedir para o usuário digitar uma placa (ReadLine) e adicionar na lista "veiculos"
            
            Console.WriteLine("Digite a placa do veículo para estacionar (formato mercosul):");
            //Lerá o valor digitado pelo usuário e verificará se é válido ou não 
            var placa = pedirPlaca();
            veiculos.Add(placa);
        }

        private string pedirPlaca()
        {
            Regex regex = new Regex("[A-Z]{3}[0-9][0-9A-Z][0-9]{2}");
            string? placa = null;
            while (true)
            {
                var placaValida = true;
                placa=  Console.ReadLine();
                if (string.IsNullOrEmpty(placa))
                {
                    Console.WriteLine("A placa não pode ser um valor nulo/vazio");
                    placaValida = false;
                }

                var MatchedValuesInRegex = regex.Match(placa);
                if (!MatchedValuesInRegex.Success)
                {
                    Console.WriteLine("O formato da placa é o do Mercosul. Terá que digitar outra vez");
                    placaValida = false;
                }

                if (placaValida is true)
                {
                    return placa;
                }
            }
        }

        private int pedirTotalHoras()
        {
            int horas = 0;
            while (true)
            {
                var horasValidas = true;
                horas = int.Parse(Console.ReadLine());
                if (horas < 0)
                {
                    Console.WriteLine("O número de hora não pode ser menor do que 0. Digite outra vez");
                    horasValidas = false;
                }

                if (horasValidas is true)
                {
                    return horas;
                }
            }
        }
        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");

            // Pedir para o usuário digitar a placa e armazenar na variável placa
            // *IMPLEMENTE AQUI*
            var placa = pedirPlaca();

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper().Equals(placa.ToUpper())))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                // TODO: Pedir para o usuário digitar a quantidade de horas que o veículo permaneceu estacionado,
                // TODO: Realizar o seguinte cálculo: "precoInicial + precoPorHora * horas" para a variável valorTotal                

                var horas = pedirTotalHoras();
                decimal valorTotal = precoInicial + precoPorHora*horas; 

                // TODO: Remover a placa digitada da lista de veículos
                veiculos.Remove(placa);

                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                // TODO: Realizar um laço de repetição, exibindo os veículos estacionados
                foreach (var veiculo in veiculos)
                {
                    Console.WriteLine("veículo estacionado: "+veiculo);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
