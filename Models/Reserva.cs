namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            // TODO: Verificar se a capacidade é maior ou igual ao número de hóspedes sendo recebido
            if (Suite?.Capacidade >= hospedes?.Count)
                Hospedes = hospedes;
            else
            {
                // TODO: Retornar uma exception caso a capacidade seja menor que o número de hóspedes recebido
                throw new Exception($"Que pena, a quantidade de hospedes ({hospedes.Count}) " +
                                    $"é maior que a capacidade da Suite ({Suite.Capacidade}) =/");
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            // TODO: Retorna a quantidade de hóspedes (propriedade Hospedes)
            return Hospedes?.Count ?? 0;
        }

        public decimal CalcularValorDiaria()
        {
            // TODO: Retorna o valor da diária
            decimal valor = Suite != null && DiasReservados > 0 ? DiasReservados * Suite.ValorDiaria : 0;

            // Regra: Caso os dias reservados forem maior ou igual a 10, conceder um desconto de 10%
            if (DiasReservados >= 10)
                valor = valor / 100 * 90;

            return valor;
        }
    }
}
