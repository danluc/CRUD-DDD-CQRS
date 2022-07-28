using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Usuario.Servico.Comandos.Usuarios.AtualizarUsuario;
using Usuario.Servico.Comandos.Usuarios.CadastrarUsuario;
using Usuario.Servico.Comandos.Usuarios.ExcluirUsuario;
using Usuario.Servico.Consultas.Usuarios.ListarUsuarios;
using Usuario.Servico.Consultas.Usuarios.SelecionarUsuarioPorId;
using Usuarios.Dominio.DTOs;

namespace Usuarios.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UsuariosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet()]
        public async Task<ActionResult> Get()
        {
            var result = await _mediator.Send(new ParametroListarUsuarios());
            if (!result.Sucesso)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult> Get(int Id)
        {
            var result = await _mediator.Send(new ParametroSelecionarUsuarioPorId(Id));
            if (!result.Sucesso)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UsuarioDTO dados)
        {
            var result = await _mediator.Send(new ParametroCadastrarUsuario(dados));
            if (!result.Sucesso)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPut("{Id}")]
        public async Task<ActionResult> Put([FromBody] UsuarioDTO dados, int Id)
        {
            var result = await _mediator.Send(new ParametroAtualizarUsuario(dados, Id));
            if (!result.Sucesso)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult> Delete(int Id)
        {
            var result = await _mediator.Send(new ParametroExcluirUsuario(Id));
            if (!result.Sucesso)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
