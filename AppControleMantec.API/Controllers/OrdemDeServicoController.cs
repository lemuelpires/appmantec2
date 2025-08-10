using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AppControleMantec.Application.DTOs;
using AppControleMantec.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AppControleMantec.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdemDeServicoController : ControllerBase
    {
        private readonly IOrdemDeServicoAppService _ordemDeServicoAppService;

        public OrdemDeServicoController(IOrdemDeServicoAppService ordemDeServicoAppService)
        {
            _ordemDeServicoAppService = ordemDeServicoAppService ?? throw new ArgumentNullException(nameof(ordemDeServicoAppService));
        }

        // GET: api/ordemdeservico
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrdemDeServicoDTO>>> GetOrdensDeServico()
        {
            try
            {
                var ordensDeServico = await _ordemDeServicoAppService.GetOrdensDeServicoAsync();
                return Ok(ordensDeServico);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao recuperar ordens de serviço: {ex.Message}");
            }
        }

        // GET: api/ordemdeservico/{id}
        [HttpGet("{id}", Name = "GetOrdemDeServicoById")]
        public async Task<ActionResult<OrdemDeServicoDTO>> GetOrdemDeServicoById(string id)
        {
            try
            {
                var ordemDeServico = await _ordemDeServicoAppService.GetOrdemDeServicoByIdAsync(id);
                if (ordemDeServico == null)
                {
                    return NotFound();
                }
                return Ok(ordemDeServico);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao recuperar ordem de serviço: {ex.Message}");
            }
        }

        // GET: api/ordemdeservico/ativas
        [HttpGet("ativas")]
        public async Task<ActionResult<IEnumerable<OrdemDeServicoDTO>>> GetOrdensDeServicoAtivas()
        {
            try
            {
                var ordensDeServicoAtivas = await _ordemDeServicoAppService.GetOrdensDeServicoAtivasAsync();
                return Ok(ordensDeServicoAtivas);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao recuperar ordens de serviço ativas: {ex.Message}");
            }
        }

        // POST: api/ordemdeservico
        [HttpPost]
        public async Task<ActionResult<string>> CriarOrdemDeServico([FromBody] OrdemDeServicoDTO ordemDeServicoDto)
        {
            try
            {
                // Verifique se o Id está vazio ou nulo
                if (string.IsNullOrEmpty(ordemDeServicoDto.Id))
                {
                    ordemDeServicoDto.Id = null; // Garanta que o Id seja null para o serviço de aplicação gerar um novo
                }

                var ordemDeServicoId = await _ordemDeServicoAppService.InsertOrdemDeServicoAsync(ordemDeServicoDto);
                return CreatedAtAction(nameof(GetOrdemDeServicoById), new { id = ordemDeServicoId }, ordemDeServicoId);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao criar ordem de serviço: {ex.Message}");
            }
        }

        // PUT: api/ordemdeservico/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarOrdemDeServico(string id, [FromBody] OrdemDeServicoDTO ordemDeServicoDto)
        {
            try
            {
                ordemDeServicoDto.Id = id;
                await _ordemDeServicoAppService.UpdateOrdemDeServicoAsync(ordemDeServicoDto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao atualizar ordem de serviço: {ex.Message}");
            }
        }

        // PUT: api/ordemdeservico/desativar/{id}
        [HttpPut("desativar/{id}")]
        public async Task<IActionResult> DesativarOrdemDeServico(string id)
        {
            try
            {
                await _ordemDeServicoAppService.DesativarOrdemDeServicoAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao desativar ordem de serviço: {ex.Message}");
            }
        }

        // PUT: api/ordemdeservico/ativar/{id}
        [HttpPut("ativar/{id}")]
        public async Task<IActionResult> AtivarOrdemDeServico(string id)
        {
            try
            {
                await _ordemDeServicoAppService.AtivarOrdemDeServicoAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao ativar ordem de serviço: {ex.Message}");
            }
        }
    }
}
