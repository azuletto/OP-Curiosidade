using Application.Input.Commands.AdminContext;
using Application.Input.Handlers.AdminContext;
using Application.Output.Results;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class AdminController : ControllerBase
    {
        private readonly InsertAdminHandler _insertHandler;
        private readonly DeleteAdminHandler _deleteHandler;
        private readonly GetAdminHandler _getHandler;

        public AdminController(InsertAdminHandler insertHandler, DeleteAdminHandler deleteHandler, GetAdminHandler getHandler)
        {
            _insertHandler = insertHandler;
            _deleteHandler = deleteHandler;
            _getHandler = getHandler;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(Result), 500)]
        public IActionResult CreateAdmin([FromBody] InsertAdminCommand command)
        {
            var result = _insertHandler.Handle(command);

            return result.IsOk
                ? Ok(result)
                : StatusCode(result.ResultCode, result);
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(Result), 500)]
        public IActionResult DeleteAdmin([FromBody] DeleteAdminCommand command)
        {
            var result = _deleteHandler.Handle(command);

            return result.IsOk
                ? Ok(result)
                : StatusCode(result.ResultCode, result);
        }
        [HttpGet]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(Result), 404)]
        public IActionResult GetAdmin([FromQuery] GetAdminCommand command)
        {
            var result = _getHandler.Handle(command);
            return result.IsOk
                ? Ok(result)
                : StatusCode(result.ResultCode, result);
        }
    }
}