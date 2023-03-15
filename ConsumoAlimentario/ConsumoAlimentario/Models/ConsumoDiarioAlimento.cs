using System.ComponentModel.DataAnnotations.Schema;

namespace ConsumoAlimentario.Models
{
    public class ConsumoDiarioAlimento
    {
        [ForeignKey("Alimento")]
        public int Alimento_Id { get; set; }
        [ForeignKey("ConsumoDiario")]
        public int ConsumoDiario_Id { get; set; }
        public ConsumoDiario ConsumoDiario { get; set;}
        public Alimento Alimento { get; set;}
    }
}
