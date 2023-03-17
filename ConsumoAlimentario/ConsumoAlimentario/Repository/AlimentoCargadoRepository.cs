using ConsumoAlimentario.Data;
using ConsumoAlimentario.Models;
using ConsumoAlimentario.Models.Dto;
using ConsumoAlimentario.Repository.IRepository;
using System.Reflection.Metadata.Ecma335;

namespace ConsumoAlimentario.Repository
{
    public class AlimentoCargadoRepository : IAlimentoCargadoRepository
    {
        private readonly ApplicationDbContext _context;
        public AlimentoCargadoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool AgregarAlimento(AlimentoCargado alimentoCargado)
        {
            _context.AlimentoCargado.Add(alimentoCargado);
            return Guardar();
        }
        public AlimentoCargado CargarAlimentoDatos(AlimentoCargadoCrearDto alimentoCargadoCrearDto)
        {
            var alimentoBase = _context.Alimento.FirstOrDefault(a => a.Alimento_Id == alimentoCargadoCrearDto.Alimento_Id);
            AlimentoCargado alimentoCargado = new AlimentoCargado
            {
                Nombre = alimentoBase.Nombre,
                Alimento_Id = alimentoCargadoCrearDto.Alimento_Id,
                Cantidad = alimentoCargadoCrearDto.Cantidad,
                Calorias = Calcular(alimentoCargadoCrearDto.Cantidad, alimentoBase.Cantidad, alimentoBase.Calorias),
                Carbohidratos = Calcular(alimentoCargadoCrearDto.Cantidad,alimentoBase.Cantidad,alimentoBase.Carbohidratos),
                Proteina = Calcular(alimentoCargadoCrearDto.Cantidad, alimentoBase.Cantidad, alimentoBase.Proteina),
                GrasasTotales = Calcular(alimentoCargadoCrearDto.Cantidad, alimentoBase.Cantidad, alimentoBase.GrasasTotales),
                Sodio = Calcular(alimentoCargadoCrearDto.Cantidad, alimentoBase.Cantidad, alimentoBase.Sodio),
                Potasio = Calcular(alimentoCargadoCrearDto.Cantidad, alimentoBase.Cantidad, alimentoBase.Potasio),
                Fibra = Calcular(alimentoCargadoCrearDto.Cantidad, alimentoBase.Cantidad, alimentoBase.Fibra),
                Azucar = Calcular(alimentoCargadoCrearDto.Cantidad, alimentoBase.Cantidad, alimentoBase.Azucar),
                VitaminaA = Calcular(alimentoCargadoCrearDto.Cantidad, alimentoBase.Cantidad, alimentoBase.VitaminaA),
                VitaminaC = Calcular(alimentoCargadoCrearDto.Cantidad, alimentoBase.Cantidad, alimentoBase.VitaminaC),
                Calcio = Calcular(alimentoCargadoCrearDto.Cantidad, alimentoBase.Cantidad, alimentoBase.Calcio),
                Hierro = Calcular(alimentoCargadoCrearDto.Cantidad, alimentoBase.Cantidad, alimentoBase.Hierro),
            };
            return alimentoCargado;
        }
        private float Calcular(float cantidadPeso, float cantidadBase, float valorBase)
        {
            float resultado =  (cantidadPeso * valorBase) / cantidadBase;
            return resultado;
        }
        public bool Existe(int id)
        {
            return _context.AlimentoCargado.Any(a => a.AlimentoCargado_Id== id);
        }

        public bool Guardar()
        {
            return _context.SaveChanges() >= 0 ? true : false;
        }

        public bool QuitarAlimento(AlimentoCargado alimentoCargado)
        {
            _context.AlimentoCargado.Remove(alimentoCargado);
            return Guardar();
        }
    }
}
