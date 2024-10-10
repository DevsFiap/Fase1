using Microsoft.AspNetCore.Mvc;
using TechChallangeFase01.Application.Interfaces;

namespace TechChallangeFase01.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ContatosController : ControllerBase
{
    private readonly IContatosService _contatosService;
    public ContatosController(IContatosService contatosService)
    {
        _contatosService = contatosService;
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

            return Ok(contatos);
        }
        catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }  
       
    } 
}