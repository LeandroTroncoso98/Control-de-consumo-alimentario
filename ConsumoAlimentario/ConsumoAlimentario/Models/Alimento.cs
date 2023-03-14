using System.ComponentModel.DataAnnotations;

namespace ConsumoAlimentario.Models
{
    public class Alimento
    {
        [Key]
        public int Alimento_Id { get; set; }
        [Required(ErrorMessage = "Debe ingresar un nombre.")]
        [StringLength(70,ErrorMessage = "El nombre debe poseer de 2 hasta 70 caracteres.",MinimumLength = 2)]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Debe ingresar las calorías.")]
        public float Calorias { get; set; }
        [Required(ErrorMessage = "Debe ingresar los carbohidratos.")]
        public float Carbohidratos { get; set; }
        [Required(ErrorMessage = "Debe ingresar las proteínas.")]
        public float Proteina { get; set; }
        [Required(ErrorMessage = "Debe ingresar las grasas totales.")]
        public float GrasasTotales { get; set; }
        public float Sodio { get; set; }
        public float Potacio { get; set; }
        public float Fibra { get; set; }
        public float Azucar { get; set; }
        public float VitaminaA { get; set; }
        public float VitaminaC { get; set; }
        public float Calcio { get; set; }
        public float Hierro { get; set; }
        public float Cantidad { get; set; }
    }
}
