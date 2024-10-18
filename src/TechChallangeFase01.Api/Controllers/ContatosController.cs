using Microsoft.AspNetCore.Mvc;
using TechChallangeFase01.Application.Interfaces;

namespace TechChallangeFase01.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ContatosController : ControllerBase
{
    private readonly IContatosService _contatosService;
    private readonly ILogger<ContatosController> _logger;
    public ContatosController(IContatosService contatosService, ILogger<ContatosController> logger)
    {
        _contatosService = contatosService;
        _logger = logger;
    }
    [HttpGet]
    public async Task<IActionResult> GetContatos()
    {
        try
        {
            var contatos = await _contatosService.GetContatos();

            if (contatos == null)
            {
                return NoContent();
            }


            _logger.LogInformation("Consultando lista de todos os contatos");
            return Ok(contatos);
        }
        catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }  
       
    } 
}