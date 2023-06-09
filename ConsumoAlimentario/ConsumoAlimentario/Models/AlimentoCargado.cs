﻿using Microsoft.Data.SqlClient.DataClassification;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsumoAlimentario.Models
{
    public class AlimentoCargado
    {
        [Key]
        public int AlimentoCargado_Id { get; set; }
        public string Nombre { get; set; }
        [ForeignKey("Alimento")]
        public int Alimento_Id { get; set; }
        public Alimento Alimento { get; set; }
        public float Cantidad { get; set; }
        public float Calorias { get; set; }
        public float Carbohidratos { get; set; }
        public float Proteina { get; set; }
        public float GrasasTotales { get; set; }
        public float Sodio { get; set; }
        public float Potasio { get; set; }
        public float Fibra { get; set; }
        public float Azucar { get; set; }
        public float VitaminaA { get; set; }
        public float VitaminaC { get; set; }
        public float Calcio { get; set; }
        public float Hierro { get; set; }

        [ForeignKey("ConsumoDiario")]
        public int ConsumoDiario_Id { get; set; }
        public ConsumoDiario ConsumoDiario {get;set;}

    }
}
