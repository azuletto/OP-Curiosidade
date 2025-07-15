using Application.Input.Commands.AdminContext;
using Application.Output.Results;
using Application.Repositories.AdminContext;
using Microsoft.AspNetCore.Mvc;
using OpCuriosidade.Entities.PersonnelContext;
using OpCuriosidade.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Controllers { 
    [ApiController]
    [Route("[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly IAdminRepository _repository;

        public AdminController(IAdminRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public ActionResult<Result> CreateAdmin([FromBody] InsertAdminCommand command)
        {
            var admin = new Admin(command.Name, command.Email, command.IsDeleted, command.Password);

            if (!admin.Validation())
            {
                var result = new Result(400, "Admin inválido", false);
                result.SetNotifications((List<Notification>)admin.Notifications);
                return BadRequest(result);
            }

            try
            {
                _repository.InsertAdmin(admin);
                return Ok(new Result(200, "Admin inserido com sucesso", true));
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new Result(500, $"Erro ao inserir admin: {ex.Message}", false));
            }
        }
    }
}
