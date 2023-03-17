using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ConsumoAlimentario.Models.Dto
{
    public class AlimentoCargadoCrearDto
    {
        public int Alimento_Id { get; set; }
        public float Cantidad { get; set; }
    }
}
