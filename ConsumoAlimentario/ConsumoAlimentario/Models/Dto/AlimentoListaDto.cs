using System.ComponentModel.DataAnnotations;

namespace ConsumoAlimentario.Models.Dto
{
    public class AlimentoListaDto
    {
        public int Alimento_Id { get; set; }
        [Required(ErrorMessage = "Debe ingresar un nombre.")]
        [StringLength(70, ErrorMessage = "El nombre debe poseer de 2 hasta 70 caracteres.", MinimumLength = 2)]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Debe ingresar las calorías.")]
        public float Calorias { get; set; }
        [Required(ErrorMessage = "Debe ingresar los carbohidratos.")]
        public float Carbohidratos { get; set; }
        [Required(ErrorMessage = "Debe ingresar las proteínas.")]
        public float Proteina { get; set; }      
    }
}
