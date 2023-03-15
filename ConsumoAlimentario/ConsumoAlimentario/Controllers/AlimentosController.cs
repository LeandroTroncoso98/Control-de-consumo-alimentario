using AutoMapper;
using ConsumoAlimentario.Models;
using ConsumoAlimentario.Models.Dto;
using ConsumoAlimentario.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Reflection.Metadata.Ecma335;

namespace ConsumoAlimentario.Controllers
{
    [Route("api/alimentos")]
    [ApiController]
    public class AlimentosController : ControllerBase
    {
        private readonly IAlimentoRepository _AlimentoRepository;
        private readonly IMapper _Mapper;
        public AlimentosController(IAlimentoRepository alimentoRepository,IMapper mapper)
        {
            _AlimentoRepository = alimentoRepository;
            _Mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAlimentos()
        {
            var listaAlimentos = _AlimentoRepository.GetAlimentos();
            var listaAlimentosDto = new List<AlimentoListaDto>();

            foreach(var alimento in listaAlimentos)
            {
                listaAlimentosDto.Add(_Mapper.Map<AlimentoListaDto>(alimento));
            }
            return Ok(listaAlimentosDto);
        }

        [HttpGet("{alimentoId:int}",Name ="GetAlimento")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public IActionResult GetAlimento(int alimentoId)
        {
            var alimento = _AlimentoRepository.GetAlimento(alimentoId);
            if (alimento == null)
                return NotFound();
            var alimentoDto = _Mapper.Map<AlimentoDto>(alimento);
            return Ok(alimentoDto);
        }

        [HttpPost]
        [ProducesResponseType(201,Type=typeof(AlimentoCreateDto))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CreateAlimento([FromBody] AlimentoCreateDto alimentoCreateDto)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            if (alimentoCreateDto == null || alimentoCreateDto.Nombre.IsNullOrEmpty())
                return BadRequest(ModelState);
            if (_AlimentoRepository.ExisteAlimento(alimentoCreateDto.Nombre))
            {
                ModelState.AddModelError("", "Ese alimento ya exíste en la base de datos.");
                return StatusCode(404, ModelState);
            }

            var alimento = _Mapper.Map<Alimento>(alimentoCreateDto);
            if (!_AlimentoRepository.CrearAliemento(alimento))
            {
                ModelState.AddModelError("", $"Algo salío mal al guardar el registro de {alimento.Nombre}");
                return StatusCode(500,ModelState);
            }
            return CreatedAtRoute("GetAlimento", new { alimentoId = alimento.Alimento_Id },alimento);
        }

        [HttpPut("{alimentoId:int}", Name="EditAlimento")]
        [ProducesResponseType(201,Type= typeof(AlimentoCreateDto))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult EditAlimento(int alimentoId, [FromBody] AlimentoDto alimentoDto)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            if(alimentoDto == null || alimentoId != alimentoDto.Alimento_Id)
                return BadRequest(ModelState);
            var alimento = _Mapper.Map<Alimento>(alimentoDto);
            if (!_AlimentoRepository.EditarAlimento(alimento))
            {
                ModelState.AddModelError("", $"Algo salio mal al actualizar el registro {alimento.Nombre}");
                return StatusCode(500,ModelState);
            }
            return NoContent();
        }

        [HttpDelete("{alimentoId:int}",Name = "DeleteAlimento")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteAlimento(int alimentoId)
        {
            if (!_AlimentoRepository.ExisteAlimento(alimentoId))
                return NotFound();
            var alimento = _AlimentoRepository.GetAlimento(alimentoId);
            if (!_AlimentoRepository.BorrarAlimento(alimento))
            {
                ModelState.AddModelError("", $"Algo salío mal al tratar de borrar el registro {alimento.Nombre}");
                return StatusCode(500,ModelState);
            }
            return NoContent();
        }
    }
}
