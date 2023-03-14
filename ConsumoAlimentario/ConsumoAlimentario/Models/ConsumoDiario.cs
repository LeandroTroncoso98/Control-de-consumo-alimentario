namespace ConsumoAlimentario.Models
{
    public class ConsumoDiario
    {
        public int ConsumoDiario_Id { get; set; }
        public int Cliente_Id { get; set; }
        public List<Alimento> ListaDeAlimentos { get; set; }
        public float CaloriasTotales { get; set; }
    }
}
