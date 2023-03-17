namespace ConsumoAlimentario.Models.Dto
{
    public class ConsumoDiarioAlimentoVerDto
    {
        public ConsumoDiario ConsumoDiario { get; set; }
        public ICollection<AlimentoCargado> Cargados { get; set;}
    }
}
