using Application.Input.Commands.AdminContext;
using Application.Input.Commands.PersonContext;
using Application.Input.Handlers.AdminContext;
using Application.Input.Handlers.PersonContext;
using Application.Output.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    //[Authorize(Roles = "Admin")]
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class PersonsController : ControllerBase
    {
        private readonly GetAllPersonsHandler _getAllPersonsHandler;
        private readonly GetNumberOfLastMonthPersonsHandler _getNumberOfLastMonthPersonsHandler;
        private readonly GetNumberOfPendingPersonsHandler _getNumberOfPendingPersonsHandler;
        private readonly GetNumberOfPersonsHandler _getNumberOfPersonsHandler;
        private readonly GetPreviewDataToDashHandler _getPreviewDataToDashHandler;
        private readonly InsertPersonHandler _insertHandler;
        private readonly DeletePersonHandler _deleteHandler;
        public PersonsController(
            GetAllPersonsHandler getAllPersonsHandler,
            GetNumberOfLastMonthPersonsHandler getNumberOfLastMonthPersonsHandler,
            GetNumberOfPendingPersonsHandler getNumberOfPendingPersonsHandler,
            GetNumberOfPersonsHandler getNumberOfPersonsHandler,
            GetPreviewDataToDashHandler getPreviewDataToDashHandler,
            InsertPersonHandler insertHandler,
            DeletePersonHandler deleteHandler
            )
        {
            _getAllPersonsHandler = getAllPersonsHandler;
            _getNumberOfLastMonthPersonsHandler = getNumberOfLastMonthPersonsHandler;
            _getNumberOfPendingPersonsHandler = getNumberOfPendingPersonsHandler;
            _getNumberOfPersonsHandler = getNumberOfPersonsHandler;
            _getPreviewDataToDashHandler = getPreviewDataToDashHandler;
            _insertHandler = insertHandler;
            _deleteHandler = deleteHandler;
        }
        [HttpGet("/table/preview")]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(Result), 404)]
        public IActionResult GetPreviewDataToDash()
        {
            var result = _getPreviewDataToDashHandler.Handle();
            return result.IsOk
                ? Ok(result)
                : StatusCode(result.ResultCode, result);
        }
        [HttpDelete("/person" + "/" + "{id}")]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(Result), 500)]
        public IActionResult DeleteAdmin([FromBody] DeletePersonCommand command)
        {
            var result = _deleteHandler.Handle(command);

            return result.IsOk
                ? Ok(result)
                : StatusCode(result.ResultCode, result);
        }
        [HttpPost("/person")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(Result), 500)]
        public IActionResult CreatePerson([FromBody] InsertPersonCommand command)
        {
            var result = _insertHandler.Handle(command);

            return result.IsOk
                ? Ok(result)
                : StatusCode(result.ResultCode, result);
        }

        [HttpGet("/pending")]
        public IActionResult GetNumberOfPendingPersons()
        {
            var result = _getNumberOfPendingPersonsHandler.Handle();
            return result.IsOk
                ? Ok(result)
                : StatusCode(result.ResultCode, result);
        }
        [HttpGet("/lastMonth")]
        public IActionResult GetNumberOfLastMonthPersons()
        {
            var result = _getNumberOfLastMonthPersonsHandler.Handle();
            return result.IsOk
                ? Ok(result)
                : StatusCode(result.ResultCode, result);
        }
        [HttpGet("/total")]
        public IActionResult GetNumberOfPersons()
        {
            var result = _getNumberOfPersonsHandler.Handle();
            return result.IsOk
                ? Ok(result)
                : StatusCode(result.ResultCode, result);
        }

        [HttpGet("/table")]
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