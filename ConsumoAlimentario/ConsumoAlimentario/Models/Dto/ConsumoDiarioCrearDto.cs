using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsumoAlimentario.Models.Dto
{
    public class ConsumoDiarioCrearDto
    {
        [Column(TypeName = "Date")]
        public DateTime Fecha { get; set; }
    }
}
