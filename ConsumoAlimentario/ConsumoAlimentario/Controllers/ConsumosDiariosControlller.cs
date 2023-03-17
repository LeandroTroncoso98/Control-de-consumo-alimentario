using AutoMapper;
using ConsumoAlimentario.Models;
using ConsumoAlimentario.Models.Dto;
using ConsumoAlimentario.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace ConsumoAlimentario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsumosDiariosControlller : ControllerBase
    {
        private readonly IAlimentoCargadoRepository _alimentoRepository;
        private readonly IConsumoDiarioRepository _consumoDiarioRepository;
        private readonly IConsumoDiarioAlimentoRepository _consumoDiarioAlimentoRepository;
        private readonly IMapper _mapper;
        public ConsumosDiariosControlller(IAlimentoCargadoRepository alimentoRepository, IConsumoDiarioRepository consumoDiarioRepository, IConsumoDiarioAlimentoRepository consumoDiarioAlimentoRepository, IMapper mapper)
        {
            _alimentoRepository = alimentoRepository;
            _consumoDiarioRepository = consumoDiarioRepository;
            _consumoDiarioAlimentoRepository = consumoDiarioAlimentoRepository;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetConsumoDiario()
        {
            var listaConsumoDiario = _consumoDiarioRepository.GetAll();
            var listaConsumoDiarioDto = new List<ConsumoDiarioList>();
            foreach (var item in listaConsumoDiario)
            {
                listaConsumoDiarioDto.Add(_mapper.Map<ConsumoDiarioList>(item));
            }
            return Ok();
        }
        [HttpGet("consumoDiarioId:int",Name = "GetConsumoDiario")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public IActionResult GetConsumoDiario(int consumoDiarioId)
        {
            var consumoDiario = _consumoDiarioRepository.Get(consumoDiarioId);
            if(consumoDiario == null)
                return NotFound();
            var consumoDiarioDto = _mapper.Map<ConsumoDiarioList>(consumoDiario);
            return Ok(consumoDiarioDto);
        }
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(ConsumoDiarioCrearDto))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CreateConsumoDiario([FromBody] ConsumoDiarioCrearDto consumoDiarioCrearDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if(consumoDiarioCrearDto == null || consumoDiarioCrearDto.Fecha.ToString().IsNullOrEmpty())
                return BadRequest(ModelState);
            if (_consumoDiarioRepository.Existe(consumoDiarioCrearDto.Fecha))
            {
                ModelState.AddModelError("", "Ya existe un registro existente en dicha fecha");
                return StatusCode(404, ModelState);
            }
            var consumoDiario = _mapper.Map<ConsumoDiario>(consumoDiarioCrearDto);
            if (!_consumoDiarioRepository.CrearConsumoDiario(consumoDiario))
            {
                ModelState.AddModelError("",$"Algo salio mal al guardar el registro {consumoDiario.Fecha}");
                return StatusCode(500, ModelState);
            }
            return CreatedAtRoute("GetConsumoDiario", new { consumoDiarioId = consumoDiario.ConsumoDiario_Id }, consumoDiario);
        }

    }
}
