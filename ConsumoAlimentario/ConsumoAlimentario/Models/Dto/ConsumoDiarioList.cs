using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsumoAlimentario.Models.Dto
{
    public class ConsumoDiarioList
    {
        public int ConsumoDiario_Id { get; set; }
        [Column(TypeName = "Date")]
        public DateTime Fecha { get; set; }
        public float CaloriasTotales { get; set; }
        public float CarbohidratosTotales { get; set; }
        public float ProteinasTotales { get; set; }
    }
}
