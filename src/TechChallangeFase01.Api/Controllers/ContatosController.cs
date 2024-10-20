﻿using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TechChallangeFase01.Application.Dto;
using TechChallangeFase01.Application.Interfaces;
using TechChallangeFase01.Domain.Enums;

namespace TechChallangeFase01.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ContatosController : ControllerBase
{
    private readonly IContatosAppService _contatosAppService;

    public ContatosController(IContatosAppService contatosAppService)
        => _contatosAppService = contatosAppService;

    /// <summary>
    /// Obtém todos os contatos.
    /// </summary>
    /// <returns>Uma lista de contatos.</returns>
    [HttpGet("buscar-todos")]
    [SwaggerOperation(Summary = "Buscar todos os contatos")]
    [ProducesResponseType(typeof(IEnumerable<ContatoDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetContatos()
    {
        try
        {
            var contatos = await _contatosAppService.GetContatos();

            if (contatos == null)
            {
                return NoContent();
            }

            return Ok(contatos);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Obtém contatos filtrados pelo DDD.
    /// </summary>
    /// <param name="ddd">O DDD para filtrar os contatos.</param>
    /// <returns>Uma lista de contatos filtrados pelo DDD.</returns>
    [HttpGet("buscar-ddd/{ddd}")]
    [SwaggerOperation(Summary = "Buscar contatos por DDD")]
    [ProducesResponseType(typeof(IEnumerable<ContatoDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetByDDD(EnumDDD ddd)
    {
        var contatos = await _contatosAppService.ObterPorDDDAsync(ddd);
        return Ok(contatos);
    }

    /// <summary>
    /// Cria um novo contato.
    /// </summary>
    /// <param name="dto">Os dados do novo contato.</param>
    /// <returns>O contato criado.</returns>
    [HttpPost("criar-contato")]
    [SwaggerOperation(Summary = "Criar um novo contato")]
    [ProducesResponseType(typeof(ContatoDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CriarContato([FromBody] CriarContatoDto dto)
    {
        return StatusCode(201, await _contatosAppService.CriarContatoAsync(dto));
    }

    /// <summary>
    /// Atualiza um contato existente.
    /// </summary>
    /// <param name="id">O ID do contato a ser atualizado.</param>
    /// <param name="dto">Os dados atualizados do contato.</param>
    /// <returns>O contato atualizado.</returns>
    [HttpPut("atualizar-contato/{id}")]
    [SwaggerOperation(Summary = "Atualizar um contato existente")]
    [ProducesResponseType(typeof(ContatoDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> AtualizarContato(int id, AtualizarContatoDto dto)
    {
        return StatusCode(200, await _contatosAppService.AtualizarContatoAsync(id, dto));
    }

    /// <summary>
    /// Exclui um contato existente.
    /// </summary>
    /// <param name="id">O ID do contato a ser excluído.</param>
    /// <returns>Uma mensagem de sucesso.</returns>
    [HttpDelete("excluir-contato/{id}")]
    [SwaggerOperation(Summary = "Excluir um contato")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteContato(int id)
    {
        await _contatosAppService.ExcluirContatoAsync(id);
        return Ok("Contato excluído com sucesso");
    }
}