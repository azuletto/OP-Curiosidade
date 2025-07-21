using Application.Mapper.Interface;
using Application.Output.DTO;
using OpCuriosidade.Entities.PersonnelContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mapper
{
    public class AdminMapper : IMapperBase
    {
        public AdminDTO MapToDTO(Admin admin)
        {
            if (admin == null)
            {
                throw new ArgumentNullException(nameof(admin), "Admin cannot be null");
            }
            return new AdminDTO
            {
                Id = admin.Id,
                Name = admin.Name,
                Email = admin.Email,
                IsDeleted = admin.IsDeleted,
                TimeStamp = admin.TimeStamp,
                Password = admin.Password
            };
        }
        public AdminDTO MapToDTO(Task<AdminDTO> adminTask)
        {
            if (adminTask == null)
            {
                throw new ArgumentNullException(nameof(adminTask), "Task não pode ser nula");
            }

            // Obtém o resultado sincronamente (só use em casos específicos!)
            AdminDTO admin = adminTask.GetAwaiter().GetResult();

            return new AdminDTO
            {
                Id = admin.Id,
                Name = admin.Name,
                Email = admin.Email,
                IsDeleted = admin.IsDeleted,
                TimeStamp = admin.TimeStamp,
                Password = admin.Password
            };
        }
    }
}
