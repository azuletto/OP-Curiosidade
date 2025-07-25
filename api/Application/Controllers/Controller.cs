using Application.Input.Commands.AdminContext;
using Application.Input.Commands.PersonContext;
using Application.Input.Handlers.AdminContext;
using Application.Input.Handlers.PersonContext;
using Application.Output.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    [Authorize(Roles = "Admin")]
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class PersonalController : ControllerBase
    {
        private readonly InsertAdminHandler _insertHandler;
        private readonly DeleteAdminHandler _deleteHandler;
        private readonly GetAdminHandler _getHandler;
        private readonly UpdateAdminHandler _updateHandler;
        private readonly LoginAdminHandler _loginHandler;
        private readonly GetAllPersonsHandler _getAllPersonsHandler;
        private readonly GetNumberOfLastMonthPersonsHandler _getNumberOfLastMonthPersonsHandler;
        private readonly GetNumberOfPendingPersonsHandler _getNumberOfPendingPersonsHandler;
        private readonly GetNumberOfPersonsHandler _getNumberOfPersonsHandler;
        public PersonalController(
            InsertAdminHandler insertHandler,
            DeleteAdminHandler deleteHandler,
            GetAdminHandler getHandler,
            UpdateAdminHandler updateHandler,
            LoginAdminHandler loginHandler,
            GetAllPersonsHandler getAllPersonsHandler,
            GetNumberOfLastMonthPersonsHandler getNumberOfLastMonthPersonsHandler,
            GetNumberOfPendingPersonsHandler getNumberOfPendingPersonsHandler,
            GetNumberOfPersonsHandler getNumberOfPersonsHandler
            )
        {
            _insertHandler = insertHandler;
            _deleteHandler = deleteHandler;
            _getHandler = getHandler;
            _updateHandler = updateHandler;
            _loginHandler = loginHandler;
            _getAllPersonsHandler = getAllPersonsHandler;
            _getNumberOfLastMonthPersonsHandler = getNumberOfLastMonthPersonsHandler;
            _getNumberOfPendingPersonsHandler = getNumberOfPendingPersonsHandler;
            _getNumberOfPersonsHandler = getNumberOfPersonsHandler;
        }

        [HttpPost("admin")]
        [AllowAnonymous]
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
        [HttpDelete("admin"+"/"+"{id}")]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(Result), 500)]
        public IActionResult DeleteAdmin([FromBody] DeleteAdminCommand command)
        {
            var result = _deleteHandler.Handle(command);

            return result.IsOk
                ? Ok(result)
                : StatusCode(result.ResultCode, result);
        }
        [HttpGet("persons/pending")]
        public IActionResult GetNumberOfPendingPersons()
        {
            var result = _getNumberOfPendingPersonsHandler.Handle();
            return result.IsOk
                ? Ok(result)
                : StatusCode(result.ResultCode, result);
        }
        [HttpGet("persons/lastMonth")]
        public IActionResult GetNumberOfLastMonthPersons()
        {
            var result = _getNumberOfLastMonthPersonsHandler.Handle();
            return result.IsOk
                ? Ok(result)
                : StatusCode(result.ResultCode, result);
        }
        [HttpGet("persons/total")]
        public IActionResult GetNumberOfPersons()
        {
            var result = _getNumberOfPersonsHandler.Handle();
            return result.IsOk
                ? Ok(result)
                : StatusCode(result.ResultCode, result);
        }
        [HttpGet("admin")]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(Result), 404)]
        public IActionResult GetAdmin([FromQuery] GetAdminCommand command)
        {
            var result = _getHandler.Handle(command);
            return result.IsOk
                ? Ok(result)
                : StatusCode(result.ResultCode, result);
        }
        [HttpPut("admin")]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(Result), 400)]
        public IActionResult UpdateAdmin([FromBody] UpdateAdminCommand command)
        {
            var result = _updateHandler.Handle(command);
            return result.IsOk
                ? Ok(result)
                : StatusCode(result.ResultCode, result);
        }
        [HttpPost("admin/login")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(Result), 401)]
        [ProducesResponseType(typeof(Result), 404)]
        public IActionResult LoginAdmin([FromBody] LoginAdminCommand command)
        {
            var result = _loginHandler.Handle(command);
            return result.IsOk
                ? Ok(result)
                : StatusCode(result.ResultCode, result);
        }
        [HttpGet("table")]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(Result), 404)]
        public IActionResult GetAllPersons()
        {
            var result = _getAllPersonsHandler.Handle();
            return result.IsOk
                ? Ok(result)
                : StatusCode(result.ResultCode, result);
        }
    }
}